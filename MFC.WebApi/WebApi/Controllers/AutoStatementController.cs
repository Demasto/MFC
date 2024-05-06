using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Infrastructure.Identity;

using WebApi.CustomActionResult;
using WebApi.Services;

namespace WebApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class AutoStatementController(UserManager<StudentUser> userManager) : ControllerBase
{
    [HttpGet("{fileName}")]
    public async Task<IActionResult> GenerateStatement(string fileName = "test.docx")
    {
        var current = await userManager.GetUserAsync(User);
        if (current == null) return BadRequest("Пользователь не найден");
        
        var student = current.ToDTO();
        
        try
        {
            var path = FileService.PathToFile(fileName, "statements");
            
            var tempFile = FileService.CopyFile(path);
            
            var service = new AutoStatementService(tempFile);
        
            service.ReplaceValue("<имя>", student.Name.First);
            service.ReplaceValue("<фамилия>", student.Name.Second);
            service.ReplaceValue("<отчество>", student.Name.Middle);
            service.ReplaceValue("<инн>", student.INN);
            
            service.CloseDocument();
            
            var fileStream = System.IO.File.OpenRead(tempFile);
            
            return TempFileStreamResult.File(fileStream, "application/octet-stream", fileName, tempFile);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        
    }
}