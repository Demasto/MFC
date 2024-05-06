using Domain.Entities;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApi.CustomActionResult;
using WebApi.Services;

namespace WebApi.Controllers;

public class AutoFileController(
    UserManager<StudentUser> studentManager,
    UserManager<EmployeeUser> employeeManager) : ControllerBase
{
    [Authorize(Roles = Role.Student)]
    [HttpGet("student/{statementName}")]
    public async Task<IActionResult> AutoStatement(string statementName = "test.docx", ServiceType type = ServiceType.StudentStatement)
    {
        var current = await studentManager.GetUserAsync(User);
        if (current == null) return BadRequest("Пользователь не найден");
        
        var student = current.ToDTO();
        
        try
        {
            var path = FileService.PathToFile(statementName, ServiceDir.Dict[type]);
            
            var tempFile = FileService.CopyFile(path);
            
            var service = new AutoStatementService(tempFile);
        
            service.ReplaceValue("<имя>", student.Name.First);
            service.ReplaceValue("<фамилия>", student.Name.Second);
            service.ReplaceValue("<отчество>", student.Name.Middle);
            service.ReplaceValue("<инн>", student.INN);
            
            service.CloseDocument();
            
            var fileStream = System.IO.File.OpenRead(tempFile);
            
            return TempFileStreamResult.File(fileStream, "application/octet-stream", statementName, tempFile);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        
    }
}