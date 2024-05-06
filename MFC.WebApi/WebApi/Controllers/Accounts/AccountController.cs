using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Infrastructure.Identity;

namespace WebApi.Controllers.Accounts;

[Authorize]
[Route("api/[controller]/[action]")]
public class AccountController(
    UserManager<AppUser> userManager, 
    UserManager<StudentUser> studentManager, 
    UserManager<EmployeeUser> employeeManager, 
    SignInManager<AppUser> signInManager) : Controller
{

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login(string userName = "admin", string password = "admin123")
    {
        // This doesn't count login failures towards account lockout
        // To enable password failures to trigger account lockout, set lockoutOnFailure: true
            
        var result = await signInManager.PasswordSignInAsync(userName, password, true, lockoutOnFailure: false);
        var response = new Dictionary<string, object>();
        
        var current = await userManager.GetUserAsync(User);
        
        if (current == null || result.Succeeded == false)
        {
            response["Result"] = false;
            return Ok(response);
        }
        
        var role = await userManager.GetRolesAsync(current);
        response["Result"] = result.Succeeded;
        response["Role"] = role.First();
        
        
        return Ok(response);
    }
        
    [HttpGet]
    public async Task<IActionResult> CurrentUser()
    {
        Dictionary<string, object?> response;
        
        if (User.IsInRole(Role.Student))
        {
            response = await GetUser(studentManager);
            response["Role"] = Role.Student;
        }
        else if (User.IsInRole(Role.Employee))
        {
            response = await GetUser(employeeManager);
            response["Role"] = Role.Employee;
        }
        else
        {
            response = await GetUser(userManager);
            response["Role"] = Role.Admin;
        }

        return Ok(response);
    }

    private async Task<Dictionary<string, object?>> GetUser<T>(UserManager<T> manager) where T : AppUser
    {
        
        var user = await manager.GetUserAsync(User);
        
        if (user == null)
        {
            throw new ApplicationException($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
        }
        
        return user.ToDTO().ToDictionary();

    }
        

        
    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await signInManager.SignOutAsync();
        Console.WriteLine("User logged out.");
        return Ok();
    }
    
}
