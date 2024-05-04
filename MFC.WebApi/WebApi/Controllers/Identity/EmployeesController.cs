using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Infrastructure.Identity;
using WebApi.DTO;


namespace WebApi.Controllers.Identity;

[Authorize(Roles = Role.Admin)]
[Route("api/[controller]")]
public class EmployeesController(
    UserManager<EmployeeUser> userManager) : Controller
{
    [HttpGet]
    public async Task<IActionResult> GetEmployees()
    {
        var appUsers = await userManager.GetUsersInRoleAsync(Role.Employee);
        
        var employees = appUsers.Select(user => user.ToEmployee()).ToList();

        return Ok(employees);
    }
    
    // [HttpGet("{serviceNumber}")]
    // public async Task<IActionResult> FromServiceNumber(string serviceNumber)
    // {
    //     var appUsers = await userManager.GetUsersInRoleAsync(Role.Student);
    //     var student = appUsers.FirstOrDefault(student => student.ServiceNumber == serviceNumber);
    //     if (student == null)
    //         return BadRequest($"Студента с номером {serviceNumber} не существует!");
    //
    //     return Ok(student.ToStudent());
    // }
    
    [HttpPost]
    public async Task<IActionResult> AddEmployee([FromBody] EmployeeDTO employeeDTO)
    {
        var user = employeeDTO.ToIdentityUser();

        try
        {
            var result = await userManager.CreateAsync(user, employeeDTO.Password);
            if (!result.Succeeded) return BadRequest(result.Errors);
            
            var addRoleResult = await userManager.AddToRoleAsync(user, Role.Employee);
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