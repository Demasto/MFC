using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Domain.Entities.Users;
using Infrastructure.Data;
using WebApi.CustomActionResult;
using WebApi.Filters;

namespace WebApi.Controllers.Accounts;

[CustomExceptionFilter]
[Route("api/[controller]/[action]")]
public class AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, MfcContext context) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Login(string userName = "admin", string password = "admin123")
    {
        // This doesn't count login failures towards account lockout
        // To enable password failures to trigger account lockout, set lockoutOnFailure: true
        var result = await signInManager.PasswordSignInAsync(userName, password, true, lockoutOnFailure: false);
        var response = new Dictionary<string, object>();
        
        if (result.Succeeded == false)
        {
            return Ok(ApiResults.Bad());
        }
        
        var current = await userManager.GetUserAsync(User);
        
        if (current == null)
            throw new ApplicationException($"Пользователь не авторизован");
        
        response["succeeded"] = result.Succeeded;
        response["role"] = current.UserRole;
        
        return Ok(response);
    }
        
    [HttpGet]
    public async Task<IActionResult> CurrentUser()
    {
        
        // var user = userManager.Users.Include(user => user.Tasks).FirstOrDefault(user => user.UserName == User.Identity.Name);
        var user = await userManager.GetUserAsync(User);
        
        if (user == null)
            throw new ApplicationException($"Пользователь не авторизован");
        
        var response = user.ToDTO().ToDictionary();
        
        // var userTasks = context.Tasks.Where(task => task.UserId == user.Id);
        // response["tasks"] = userTasks;
        
        response["role"] = user.UserRole;
        
        return Ok(response);
    }
        

        
    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await signInManager.SignOutAsync();
        return Ok(ApiResults.Ok());
    }
    
}
