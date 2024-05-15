using System.ComponentModel.DataAnnotations;
using Domain.DTO.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Domain.Entities;
using Domain.Entities.Users;
using Infrastructure.Data;
using Infrastructure.Repo;
using WebApi.CustomActionResult;
using WebApi.Filters;
using WebApi.Services;
using WebApi.Services.Interfaces;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AutoDocController(
    UserManager<AppUser> userManager,
    IServiceRepository serviceRepository, 
    IFileService fileService,
    MfcContext context) : ControllerBase
{
    [Authorize]
    [HttpGet("{type}/{serviceName}")]
    [CustomExceptionFilter]
    public async Task<IActionResult> Auto([Required] string serviceName = "test",[Required] ServiceType type = ServiceType.StudentStatement)
    {
        var current = await userManager.GetUserAsync(User);
        if (current == null) throw new Exception("Пользователь не авторизован");

        var service = serviceRepository.Get(serviceName);
        
        var files = fileService.GetAllFromType(type);
        var fileNameWithExtension = files.FirstOrDefault(fileName => fileName.Contains(serviceName.ToLower()));
        
        if (fileNameWithExtension == null) throw new Exception("Файл не найден");

        var path = SaveDirectory.PathToFile(type, fileNameWithExtension);;
            
        var tempFile = FileService.CopyFile(path);
            
        new AutoFillDocService(tempFile).ReplaceALl(current);
        
            
        var fileStream = System.IO.File.OpenRead(tempFile);
            
        return TempFileStreamResult.File(fileStream, "application/octet-stream", fileNameWithExtension, tempFile);
    }
    [Authorize]
    [HttpGet("{taskId}")]
    [CustomExceptionFilter]
    public async Task<IActionResult> AutoCertificate([Required] long taskId)
    {
        var current = await userManager.GetUserAsync(User);
        if (current == null) throw new Exception("Пользователь не авторизован");
        if (current.UserRole is not Role.Admin) throw new Exception("Метод не доступен");

        var task = await context.Tasks.FindAsync(taskId);
        if(task == null) throw new Exception("Такой задачи не существует");
        var user = userManager.Users.FirstOrDefault(appUser => appUser.Id == task.UserId);
        if (user == null) throw new Exception($"Задача некорректна. Пользователя с UserId={task.UserId} не существует");
        
        var fileNameWithExtension = fileService.FromServiceName(task.ServiceName, ServiceType.Certificate);
            
        var tempFile = FileService.CopyFile(SaveDirectory.PathToFile(ServiceType.Certificate, fileNameWithExtension));
        
        new AutoFillDocService(tempFile).ReplaceALl(user);
            
        var fileStream = System.IO.File.OpenRead(tempFile);
            
        return TempFileStreamResult.File(fileStream, "application/octet-stream", fileNameWithExtension, tempFile);
    }
}

