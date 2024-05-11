using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Infrastructure.Repo;
using Domain.Entities.Users;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using WebApi.CustomActionResult;
using WebApi.Filters;
using Task = Domain.Entities.Task;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[CustomExceptionFilter]
public class TaskController(UserManager<AppUser> userManager, IServiceRepository serviceRepo, MfcContext context) : ControllerBase
{
    
    [HttpGet]
    [Authorize(Roles = Role.Admin)]
    public IActionResult GetAll()
    {
        return Ok(context.Tasks.ToList());
    }
    
    [HttpGet("from_current_user")]
    [Authorize]
    public async Task<IActionResult> GetFromUser()
    {
        var user = await userManager.GetUserAsync(User);
        
        if (user == null)
        {
            throw new ApplicationException($"Пользователь не авторизован");
        }
        
        var userTasks = context.Tasks.Where(task => task.UserId == user.Id);
        return Ok(ApiResults.Ok("tasks", userTasks));
    }
    
    [HttpPut("{taskId}")]
    [Authorize(Roles = Role.Admin)]
    public async Task<IActionResult> ChangeTaskState(long taskId, ProcessState newState)
    {
        var task = await context.Tasks.FindAsync(taskId);
        if (task == null)
            throw new Exception("task not found");
            
        task.State = newState;
        await context.SaveChangesAsync();
            
        return Ok(ApiResults.Ok());
    }
    
    
    [HttpPost("{serviceName}")]
    public async Task<IActionResult> Add(string serviceName)
    {
        var userId = userManager.GetUserId(User);
        if (userId == null) throw new ApplicationException($"Пользователь не авторизован");

   
        if (!serviceRepo.Contain(serviceName)) 
            throw new Exception($"Услуги с названием '{serviceName}' не существует.");
        
        await context.Tasks.AddAsync(new Task(userId, serviceName));
        
        await context.SaveChangesAsync();

        return Ok(ApiResults.Ok());
        
    }
    
    [HttpDelete("{taskId}")]
    public async Task<IActionResult> Cancel(long taskId)
    {
        
        var userId = userManager.GetUserId(User);
        if (userId == null) 
            throw new ApplicationException($"Пользователь не авторизован");
        
        var canceledTask = await context.Tasks.FindAsync(taskId);
        if (canceledTask == null) 
            throw new Exception("Task not found");

        canceledTask.State = ProcessState.Cancelled;
        await context.SaveChangesAsync();
            
        return Ok(ApiResults.Ok());
    }
    
    [Authorize(Roles = Role.Admin)]
    [HttpDelete("clear_all")]
    public IActionResult Clear()
    {
  
        context.Tasks.RemoveRange(context.Tasks);
        context.SaveChanges();
        return Ok(ApiResults.Ok());
    }
}