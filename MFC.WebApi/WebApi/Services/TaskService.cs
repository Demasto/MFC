using Domain.Entities;
using Domain.Entities.Users;
using Infrastructure.Data;
using Infrastructure.Repo;
using Microsoft.AspNetCore.Identity;
using WebApi.Services.Interfaces;

using Task = System.Threading.Tasks.Task;

namespace WebApi.Services;

public class TaskService(MfcContext context, IServiceRepository serviceRepository, IEmailService emailService) : ITaskService
{
    public IQueryable<Domain.DTO.TaskDTO> GetAll()
    {
        return context.Tasks.Select(task => task.ToDTO());
    }
    public IQueryable<Domain.DTO.TaskDTO> GetFromUser(string userId)
    {
        return context.Tasks.Where(task => task.UserId == userId).Select(task => task.ToDTO());
    }
    
    public async Task Add(string serviceName, AppUser user)
    {
        var service = serviceRepository.Get(serviceName);

        var oldTask = context.Tasks
            .Where(task => task.UserId == user.Id)
            .Select(task => task.ToDTO())
            .ToList()
            .Where(task => task.Service.NormalizedName == serviceName.ToUpper())
            .MaxBy(task => task.DateTime);
        
       
        if (oldTask != null)
        {
            Console.WriteLine(oldTask.DateTime);
            switch (oldTask.State)
            {
                case ProcessState.Created:
                    throw new Exception("Услуга уже заказана");
                
                case ProcessState.InProcess:
                    throw new Exception("Услуга уже в процессе");
                
                case ProcessState.Ready:
                    throw new Exception("Услуга уже готова");
            }
        }


        await context.Tasks.AddAsync(new Domain.Entities.Task(user, service));
        
        await context.SaveChangesAsync();

        try
        {
            if (user.Email != null)
            {
                await emailService.SendEmailAsync(user.Email, "Услуга заказана успешно!", $"<h1>Здравствуйте {user.UserName}</h1></br>Услуга \"{serviceName}\" ожидает выпонения.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
    }
    

    public async Task<Domain.Entities.Task> GetTaskById(long taskId)
    {
        var task = await context.Tasks.FindAsync(taskId);
        if (task == null)
            throw new Exception("task not found");
        return task;
    }

    public async Task ChangeStateAsync(long taskId, ProcessState newState, UserManager<AppUser> userManager)
    {
        var task = await GetTaskById(taskId);
        if (task.State == newState) return;
        task.State = newState;
        await context.SaveChangesAsync();
        
        var email = userManager.Users.FirstOrDefault(user => user.Id == task.UserId)?.Email;
        if (email != null)
        {
            await emailService.SendEmailAsync(email, $"Обновлен статус услуги '{task.ToDTO().Service.Name}'", $"<h1>Здравствуйте</h1></br>Услуга \"{task.ToDTO().Service.Name}\" переведена в статус {task.State}.");
        }
    }
    

    public async Task RemoveAsync(long taskId)
    {

        var task = GetTaskById(taskId);
        
        context.Remove(task);
        await context.SaveChangesAsync();
    }

    public void Clear()
    {
        context.Tasks.RemoveRange(context.Tasks);
        context.SaveChanges();
    }
}