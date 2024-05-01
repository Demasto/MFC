using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTO;


namespace WebApi.Controllers;

[Authorize(Roles = Role.Admin)]
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
    public async Task<IActionResult> AddStudent([FromBody] StudentDTO studentDTO)
    {
        var user = studentDTO.ToIdentityUser();

        try
        {
            var result = await userManager.CreateAsync(user, studentDTO.Password);
            if (!result.Succeeded) return BadRequest(result.Errors);
            
            var addRoleResult = await userManager.AddToRoleAsync(user, Role.Student);
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