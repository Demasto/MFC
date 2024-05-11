using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Infrastructure.Repo;
using Domain.Entities.Users;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Task = Domain.Entities.Task;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
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
            throw new ApplicationException($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
        }
        
        return Ok(context.Tasks.Where(task => task.UserId == user.Id));
    }
    
    [HttpPut("{taskId}")]
    [Authorize(Roles = Role.Admin)]
    public async Task<IActionResult> ChangeTaskState(long taskId, ProcessState newState)
    {
        var task = await context.Tasks.FindAsync(taskId);
        if (task == null) return BadRequest("task not found");
        task.State = newState;
        await context.SaveChangesAsync();
        return Ok(task);
    }
    
    
    [HttpPost("{serviceName}")]
    public async Task<IActionResult> Add(string serviceName)
    {
        var userId = userManager.GetUserId(User);
        if (userId == null) throw new ApplicationException($"Unable to load user.");

        if (!serviceRepo.Contain(serviceName)) return BadRequest($"Услуги с названием '{serviceName}' не существует.");
        
        await context.Tasks.AddAsync(new Task()
        {
            UserId = userId,
            ServiceName = serviceName
        });
        
        await context.SaveChangesAsync();

        return Ok();
    }
    
    [HttpDelete("{taskId}")]
    public async Task<IActionResult> Cancel(long taskId)
    {
        
        var userId = userManager.GetUserId(User);
        if (userId == null) throw new ApplicationException($"Unable to load user.");

        var canceledTask = await context.Tasks.FindAsync(taskId);
        if (canceledTask == null) return BadRequest("Task not found");
        
        canceledTask.State = ProcessState.Cancelled;
        await context.SaveChangesAsync();

        return Ok();
        
    }
    
    [Authorize(Roles = Role.Admin)]
    [HttpDelete("clear_all")]
    public IActionResult Clear()
    {
        context.Tasks.RemoveRange(context.Tasks.ToList());
        context.SaveChanges();
        return Ok();
    }
}