using System.ComponentModel.DataAnnotations;
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
public class EmployeesController(
    UserManager<EmployeeUser> employeeManager) : ControllerBase
{
    [HttpGet]
    public IActionResult GetEmployees()
    {
        var employees = employeeManager.Users.Select(user => user.ToDTO());
        
        return Ok(employees);
    }
    
    
    [HttpGet("fromPost")]
    public IActionResult FromPost([Required] string post = "")
    {
        var response = employeeManager.Users.Where(user => user.Post == post).Select(user => user.ToDTO());

        return Ok(response);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddEmployee([FromBody] EmployeeDTO employeeDTO)
    {
        var user = employeeDTO.ToIdentityUser();

      
        var result = await employeeManager.CreateAsync(user, employeeDTO.Password);
        if (!result.Succeeded) return Ok(result);
            
        var addRoleResult = await employeeManager.AddToRoleAsync(user, Role.Employee);
        if (!addRoleResult.Succeeded) return Ok(addRoleResult);
        
        
        return Ok(ApiResults.Ok());
    }
    
    [HttpPost("initialize")]
    public async Task<IActionResult> InitEmployees()
    {
        var path = Path.Combine(Directory.GetCurrentDirectory(), "employees.json");
        
        Console.WriteLine(path);
        if (!System.IO.File.Exists(path))
            throw new FileNotFoundException("Файл students.json не найден!");

        using var reader = new StreamReader(path);
        var jsonStudentsArray = await reader.ReadToEndAsync();

        var employees = JsonSerializer.Deserialize<List<EmployeeDTO>>(jsonStudentsArray, Options);
        if (employees == null) throw new Exception("Список пуст.");
        
        foreach (var employeeDTO in employees)
        {
            await AddEmployee(employeeDTO);
        }
        return Ok(employees);
    }
    private static readonly JsonSerializerOptions Options = new() { PropertyNameCaseInsensitive = true, };
}