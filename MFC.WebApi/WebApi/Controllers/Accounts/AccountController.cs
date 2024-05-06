using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Infrastructure.Identity;

namespace WebApi.Controllers.Identity;

[Authorize]
[Route("api/[controller]/[action]")]
public class AccountController(
    UserManager<AppUser> userManager, 
    UserManager<StudentUser> studentManager, 
    UserManager<EmployeeUser> employeManager, 
    SignInManager<AppUser> signInManager,
    IConfiguration configuration) : Controller
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
        
        if (User.IsInRole(Role.Student))
        {
            var student = await studentManager.GetUserAsync(User);
            return Ok(student.ToDTO().ToDictionary());

        }
        else if (User.IsInRole(Role.Employee))
        {
            var employee = await employeManager.GetUserAsync(User);
            return Ok(employee.ToDTO().ToDictionary());
        }
        else
        {
            var admin = await userManager.GetUserAsync(User);
            return Ok(admin.ToDTO().ToDictionary());
        }
        

        
        // var response = user.ToDTO().ToDictionary();
        // var roles = await userManager.GetRolesAsync(user);
        // response["Role"] = roles.First();
        //
        // return Ok(response);
    }

    // public async Task<IActionResult> GetUser<T>(T manager) where T : UserManager<T>
    // {
    //     var user = await manager.GetUserAsync(User);
    //     
    //     if (user == null)
    //     {
    //         throw new ApplicationException($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
    //     }
    // }
        

        
    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await signInManager.SignOutAsync();
        Console.WriteLine("User logged out.");
        return Ok();
    }
    
}
