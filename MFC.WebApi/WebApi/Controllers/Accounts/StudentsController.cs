using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Domain.Entities;
using Domain.Entities.Users;
using Domain.DTO.Users;
using WebApi.CustomActionResult;


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
        
        var result = await studentManager.CreateAsync(user, studentDTO.Password);
        if (!result.Succeeded) return Ok(result);
            
        var addRoleResult = await studentManager.AddToRoleAsync(user, Role.Student);
        if (!addRoleResult.Succeeded) return Ok(result);
        
        return Ok(ApiResults.Ok());
    }
    
    [HttpPost("initialize")]
    public async Task<IActionResult> InitStudents()
    {
        var path = Path.Combine(Directory.GetCurrentDirectory(), "students.json");
        
        Console.WriteLine(path);
        if (!System.IO.File.Exists(path))
            throw new FileNotFoundException("Файл students.json не найден!");

        using var reader = new StreamReader(path);
        var jsonStudentsArray = await reader.ReadToEndAsync();

        var students = JsonSerializer.Deserialize<List<StudentDTO>>(jsonStudentsArray, Options);
        if (students == null) throw new Exception("Список пуст.");
        
        foreach (var studentDTO in students)
        {
            await AddStudent(studentDTO);
        }
        return Ok(students);
    }

    private static readonly JsonSerializerOptions Options = new() { PropertyNameCaseInsensitive = true, };

}