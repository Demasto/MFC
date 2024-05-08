using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Infrastructure.Identity;

using Infrastructure.DTO;


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
    public IActionResult FromPost(string post = "")
    {
        var response = employeeManager.Users.Where(user => user.Post == post).Select(user => user.ToDTO());

        return Ok(response);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddEmployee([FromBody] EmployeeDTO employeeDTO)
    {
        var user = employeeDTO.ToIdentityUser();

        try
        {
            var result = await employeeManager.CreateAsync(user, employeeDTO.Password);
            if (!result.Succeeded) return BadRequest(result.Errors);
            
            var addRoleResult = await employeeManager.AddToRoleAsync(user, Role.Employee);
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