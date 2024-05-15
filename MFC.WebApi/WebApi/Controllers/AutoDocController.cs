using Domain.DTO.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Domain.Entities;
using Domain.Entities.Users;
using Infrastructure.Repo;
using WebApi.CustomActionResult;
using WebApi.Filters;
using WebApi.Services;
using WebApi.Services.Interfaces;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AutoDocController(UserManager<AppUser> userManager, IServiceRepository serviceRepository, IFileService fileService) : ControllerBase
{
    [Authorize]
    [HttpGet("{type}/{serviceName}")]
    [CustomExceptionFilter]
    public async Task<IActionResult> Auto(string serviceName = "test", ServiceType type = ServiceType.StudentStatement)
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
}

