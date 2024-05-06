using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Infrastructure.Identity;

namespace WebApi.Controllers.Identity;

[Authorize]
[Route("api/[controller]/[action]")]
public class AccountController(
    UserManager<AppUser> userManager, 
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
        var user = await userManager.GetUserAsync(User);
        if (user == null)
        {
            throw new ApplicationException($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
        }
            
        var response = user.ToDTO().ToDictionary();
        var roles = await userManager.GetRolesAsync(user);
        response["Role"] = roles.First();

        return Ok(response);
    }
        

        
    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await signInManager.SignOutAsync();
        Console.WriteLine("User logged out.");
        return Ok();
    }
    
}
