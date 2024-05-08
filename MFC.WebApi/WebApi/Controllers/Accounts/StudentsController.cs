using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Domain.Entities;
using Domain.Entities.Users;
using Domain.DTO.Users;



namespace WebApi.Controllers.Accounts;

[Authorize(Roles = Role.Admin)]
[Route("api/[controller]")]
public class StudentsController(UserManager<StudentUser> studentManager) : ControllerBase
{
    [HttpGet]
    public IActionResult GetStudents()
    {
        
        var studentsListResponse = studentManager.Users.Select(user => user.ToDTO());

        return Ok(studentsListResponse);
    }
    
    [HttpGet("{serviceNumber}")]
    public IActionResult FromServiceNumber(string serviceNumber)
    {
        
        var student = studentManager.Users.FirstOrDefault(student => student.ServiceNumber == serviceNumber);
        
        if (student == null)
            return BadRequest($"Студента с номером {serviceNumber} не существует!");

        return Ok(student.ToDTO());
    }
    
    [HttpPost]
    public async Task<IActionResult> AddStudent([FromBody] StudentDTO studentDTO)
    {
        var user = studentDTO.ToIdentityUser();

        try
        {
            var result = await studentManager.CreateAsync(user, studentDTO.Password);
            if (!result.Succeeded) return BadRequest(result.Errors);
            
            var addRoleResult = await studentManager.AddToRoleAsync(user, Role.Student);
            if (!addRoleResult.Succeeded) return BadRequest(addRoleResult.Errors);
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.GetType().Name);
        }
        
        return Ok();
    }
}