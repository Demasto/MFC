using System.Dynamic;
using System.Text.Json;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace WebApi.Controllers;

[Authorize(Roles = "admin")]
[Route("api/[controller]")]
public class StudentsController(
    UserManager<Student> userManager, 
    SignInManager<Student> signInManager) : Controller
{
    [HttpGet]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> GetAll()
    {
        var students = await userManager.GetUsersInRoleAsync("student");
        
        var studentsListResponse = students.Select(student => student.ToResponse()).ToList();

        return Ok(studentsListResponse);
    }
}