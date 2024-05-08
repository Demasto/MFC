using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Domain.Entities;
using Domain.Entities.Users;
using WebApi.CustomActionResult;
using WebApi.Services;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AutoDocController(UserManager<AppUser> userManager) : ControllerBase
{
    [Authorize]
    [HttpGet("{type}/{file}")]
    public async Task<IActionResult> Auto(string file = "test.docx", ServiceType type = ServiceType.StudentStatement)
    {
        var current = await userManager.GetUserAsync(User);
        if (current == null) return BadRequest("Пользователь не найден");
        
        // TODO var student = current as StudentUser;
        
        var student = current.ToDTO();
        
        try
        {
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
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        
    }
}