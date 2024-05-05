using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Infrastructure.Identity.Users;

using WebApi.CustomActionResult;
using WebApi.Services;

namespace WebApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class AutoStatementController(UserManager<StudentUser> userManager) : ControllerBase
{
    [HttpGet("{fileName}")]
    public async Task<IActionResult> GenerateStatement(string fileName)
    {
        var current = await userManager.GetUserAsync(User);
        if (current == null) return BadRequest("Пользователь не найден");
        var student = current.ToEntity();
        
        try
        {
            var path = SaveDirectory.CopyFile(fileName);
            
            var service = new AutoStatementService(path);
        
            service.ReplaceValue("<имя>", student.Name.First);
            service.ReplaceValue("<фамилия>", student.Name.Second);
            service.ReplaceValue("<отчество>", student.Name.Middle);
            service.ReplaceValue("<инн>", student.INN);
            
            service.CloseDocument();
            
            var fileStream = System.IO.File.OpenRead(path);
            
            return TempFileStreamResult.File(fileStream, "application/octet-stream", fileName, path);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        
    }
}