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
            .Select(task => task.ToDTO()).ToList()
            .Where(task => task.Service.NormalizedName.Equals(serviceName, StringComparison.CurrentCultureIgnoreCase))
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
        
        var task = new Domain.Entities.Task(user, service);
        await context.Tasks.AddAsync(task);
        
        await context.SaveChangesAsync();

        try
        {
            if (user.Email != null)
            {
                await emailService.SendEmailAsync(user.Email, "Услуга заказана успешно!", $"<h1>Здравствуйте {task.UserFullName}!</h1></br>Услуга \"{serviceName}\" ожидает выпонения.");
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
        var taskDTO = task.ToDTO();
        
        var email = userManager.Users.FirstOrDefault(user => user.Id == task.UserId)?.Email;
        if (email != null)
        {
            var message = taskDTO.State switch
            {
                ProcessState.Ready =>
                    $"Результат услуги \"{taskDTO.Service.Name}\" готов к выдаче! Подходите в аудиторию 1215, не забудьте свой паспорт!",
                ProcessState.Created =>
                    $"<h1>Здравствуйте {taskDTO.UserFullName}!</h1></br>Услуга \"{taskDTO.Service.Name}\" создана и ожидает выпонения.",
                _ =>
                    $"<h1>Здравствуйте {taskDTO.UserFullName}!</h1></br>Изменен статус услуги \"{taskDTO.Service.Name}\" на {taskDTO.State}."
            };
            await emailService.SendEmailAsync(email, taskDTO.Service.Name, message);
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