using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Domain.Entities;
using Domain.Entities.Users;

using WebApi.CustomActionResult;
using WebApi.Filters;
using WebApi.Services.Interfaces;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[CustomExceptionFilter]
public class TaskController(UserManager<AppUser> userManager, ITaskService taskService) : ControllerBase
{
    [HttpGet]
    [Authorize(Roles = Role.Admin)]
    public IActionResult GetAll()
    {
        return Ok(taskService.GetAll());
    }
    
    [HttpGet("from_current_user")]
    [Authorize]
    public IActionResult GetFromUser()
    {
        var userId = userManager.GetUserId(User);
        
        if (userId == null)
        {
            throw new ApplicationException($"Пользователь не авторизован");
        }
        
        var userTasks = taskService.GetFromUser(userId);
        
        return Ok(ApiResults.Ok("tasks", userTasks));
    }
    
    [HttpPut("{taskId}")]
    [Authorize(Roles = Role.Admin)]
    public async Task<IActionResult> ChangeTaskState(long taskId, [Required] ProcessState newState)
    {
        await taskService.ChangeStateAsync(taskId, newState, userManager);
        
        return Ok(ApiResults.Ok());
    }
    
    [Authorize]
    [HttpPost("{serviceName}")]
    public async Task<IActionResult> Add(string serviceName)
    {
        var user = await userManager.GetUserAsync(User);
        if (user == null) throw new ApplicationException($"Пользователь не авторизован");

        await taskService.Add(serviceName, user);

        return Ok(ApiResults.Ok());
        
    }
    
    [Authorize]
    [HttpDelete("{taskId}")]
    public async Task<IActionResult> Remove(long taskId)
    {
        await taskService.RemoveAsync(taskId);
        
        return Ok(ApiResults.Ok());
    }
    
    [Authorize(Roles = Role.Admin)]
    [HttpDelete("clear_all")]
    public IActionResult Clear()
    {
        taskService.Clear();
        return Ok(ApiResults.Ok());
    }
}