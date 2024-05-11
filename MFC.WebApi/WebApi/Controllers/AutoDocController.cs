using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Domain.Entities;
using Domain.Entities.Users;
using WebApi.CustomActionResult;
using WebApi.Filters;
using WebApi.Services;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AutoDocController(UserManager<AppUser> userManager) : ControllerBase
{
    [Authorize]
    [HttpGet("{type}/{file}")]
    [CustomExceptionFilter]
    public async Task<IActionResult> Auto(string file = "test.docx", ServiceType type = ServiceType.StudentStatement)
    {
        var current = await userManager.GetUserAsync(User);
        if (current == null) throw new Exception("Пользователь не авторизован");
        
        // TODO var student = current as StudentUser;
        
        var student = current.ToDTO();
        
    
        var path = SaveDirectory.PathToFile(type, file);;
            
        var tempFile = FileService.CopyFile(path);
            
        var service = new AutoFillDocService(tempFile);
        
        service.ReplaceValue("<имя>", student.Name.First);
        service.ReplaceValue("<фамилия>", student.Name.Second);
        service.ReplaceValue("<отчество>", student.Name.Middle);
        service.ReplaceValue("<инн>", student.INN);
            
        service.CloseDocument();
            
        var fileStream = System.IO.File.OpenRead(tempFile);
            
        return TempFileStreamResult.File(fileStream, "application/octet-stream", file, tempFile);
        
    }
}