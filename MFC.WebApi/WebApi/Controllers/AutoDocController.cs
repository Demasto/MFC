using Domain.DTO.Users;
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
        
        var path = SaveDirectory.PathToFile(type, file);;
            
        var tempFile = FileService.CopyFile(path);
            
        var service = new AutoFillDocService(tempFile);

        var appUserDto = current.ToDTO();


        
        service.ReplaceValue("<имя>", appUserDto.Name.First);
        service.ReplaceValue("<фамилия>", appUserDto.Name.Second);
        service.ReplaceValue("<отчество>", appUserDto.Name.Middle);
        
        var parentCaseName = appUserDto.Name.ToParent();
        service.ReplaceValue("<имя-р>", parentCaseName.First);
        service.ReplaceValue("<фамилия-р>", parentCaseName.Second);
        service.ReplaceValue("<отчество-р>", parentCaseName.Middle);
        
        service.ReplaceValue("<инн>", appUserDto.INN);
        service.ReplaceValue("<телефон>", appUserDto.PhoneNumber);
        
        switch (current.UserRole)
        {
            case Role.Student:
            {
                var studentDTO = appUserDto as StudentDTO;
                service.ReplaceValue("<группа>", studentDTO.Group);
                service.ReplaceValue("<направление>", studentDTO.DirectionOfStudy);
                service.ReplaceValue("<номер>", studentDTO.ServiceNumber);
                break;
            }
            case Role.Employee:
            {
                var employeeDTO = appUserDto as EmployeeDTO;
                service.ReplaceValue("<должность>", employeeDTO.Post);
                service.ReplaceValue("<институт>", employeeDTO.Institute);
                break;
            }
        }
            
        service.CloseDocument();
            
        var fileStream = System.IO.File.OpenRead(tempFile);
            
        return TempFileStreamResult.File(fileStream, "application/octet-stream", file, tempFile);
        
    }
}

