using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using Domain.DTO.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Domain.Entities;
using Domain.Entities.Users;
using Infrastructure.Data;
using Infrastructure.Repo;
using Microsoft.AspNetCore.Mvc.Routing;
using WebApi.CustomActionResult;
using WebApi.Filters;
using WebApi.Services;
using WebApi.Services.Interfaces;

namespace WebApi.Controllers;

[CustomExceptionFilter]
[Route("api/[controller]")]
[ApiController]
public class AutoDocController(
    UserManager<AppUser> userManager,
    IServiceRepository serviceRepository, 
    IFileService fileService,
    MfcContext context) : ControllerBase
{
    [Authorize]
    [HttpGet("service/{serviceName}")]
    public async Task<IActionResult> Auto([Required] string serviceName)
    {
        var current = await userManager.GetUserAsync(User);
        if (current == null) throw new Exception("Пользователь не авторизован");

        var service = serviceRepository.Get(serviceName);
        
        return AutoDocResult(current, service);
    }


    
    [Authorize(Roles = Role.Admin)]
    [HttpGet("{taskId}")]
    public async Task<IActionResult> AutoCertificate([Required] long taskId)
    {
        var current = await userManager.GetUserAsync(User);
        if (current == null) throw new Exception("Пользователь не авторизован");

        var task = await context.Tasks.FindAsync(taskId);
        if(task == null) throw new Exception("Такой задачи не существует");
        
        var user = userManager.Users.FirstOrDefault(appUser => appUser.Id == task.UserId);
        
        var service = JsonSerializer.Deserialize<Service>(task.Service);
        if (service == null) throw new Exception("Услуга не распознана");
        
        if (user == null) throw new Exception($"Задача {task.Id}({service.Name}) некорректна. Пользователя с UserId={task.UserId} не существует");

        return AutoDocResult(user, service);

    }
    
    private OkObjectResult AutoDocResult(AppUser current, Service service)
    {
        var fileNameWithExtension = fileService.FromServiceName(service.Name, service.Type);
        
        var autoName = CreateAutoName(current, fileNameWithExtension);
        
        var result = Ok(ApiResults.Ok("url", CreateLink(autoName)));
        
        if (!StaticDirectory.IsExist(autoName, Dir.Auto))
        {
            AutoFillDocService.Generate(current, fileNameWithExtension, autoName, service.Type);
        }
        // TODO если файл существует, узнать как давно он был создан
       
        return result;
    }
    
    private static string CreateAutoName(AppUser user, string file)
    {
        var name = JsonSerializer.Deserialize<NameDTO>(user.Name);
        return $"{name?.Second}-{file}";
    }
    private string CreateLink(string name)
    {
        var s = Request.IsHttps ? "s" : "";
        return $"http{s}://{Request.Host}/auto/{name}";
    }
    
}

