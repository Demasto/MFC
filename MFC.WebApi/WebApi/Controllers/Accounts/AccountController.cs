using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Infrastructure.Identity;

namespace WebApi.Controllers.Accounts;

[Authorize]
[Route("api/[controller]/[action]")]
public class AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) : Controller
{
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login(string userName = "admin", string password = "admin123")
    {
        // This doesn't count login failures towards account lockout
        // To enable password failures to trigger account lockout, set lockoutOnFailure: true
        
        var result = await signInManager.PasswordSignInAsync(userName, password, true, lockoutOnFailure: false);
        var response = new Dictionary<string, object>();
        
        if (result.Succeeded == false)
        {
            response["succeeded"] = false;
            return Ok(response);
        }
        
        var current = await userManager.GetUserAsync(User);
        
        if (current == null)
        {
            throw new ApplicationException($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
        }
        
        response["succeeded"] = result.Succeeded;
        response["role"] = current.UserRole;
        
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
        response["role"] = user.UserRole;
        
        return Ok(response);
    }
        

        
    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await signInManager.SignOutAsync();
        return Ok();
    }
    
}
