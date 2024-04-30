using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTO;


namespace WebApi.Controllers;

[Authorize(Roles = "admin")]
[Route("api/[controller]/[action]")]
public class AdminController(
    UserManager<AppUser> userManager, 
    SignInManager<AppUser> signInManager) : Controller
{
    [HttpGet]
    public async Task<IActionResult> GetStudents()
    {
        var appUsers = await userManager.GetUsersInRoleAsync(Role.Student);
        
        var studentsListResponse = appUsers.Select(user => user.ToStudent()).ToList();

        return Ok(studentsListResponse);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddStudent(StudentDTO student)
    {
        var user = student.ToIdentityUser();

        try
        {
            var result = await userManager.CreateAsync(user, student.Password);
            var addRoleResult = await userManager.AddToRoleAsync(user, Role.Student);
            
            if (result.Succeeded && addRoleResult.Succeeded)
            {
                return Ok();
            }

            return BadRequest(result.Errors);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
    }
}