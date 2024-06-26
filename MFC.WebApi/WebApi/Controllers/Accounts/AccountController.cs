using System.ComponentModel.DataAnnotations;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Domain.Entities.Users;
using WebApi.CustomActionResult;
using WebApi.Filters;

namespace WebApi.Controllers.Accounts;

[CustomExceptionFilter]
[Route("api/[controller]/[action]")]
public class AccountController(
    UserManager<AppUser> userManager,
    SignInManager<AppUser> signInManager) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Login([Required] string userName, [Required] string password)
    {
        var result = await signInManager.PasswordSignInAsync(userName, password, true, lockoutOnFailure: false);
        var response = new Dictionary<string, object>();
        
        if (result.Succeeded == false)
        {
            return Ok(ApiResults.Bad());
        }

        var isInRole = false;
        foreach (var role in Role.Array)
        {
            if (!User.IsInRole(role)) continue;
            isInRole = true;
            response["role"] = role;
        }
        if (!isInRole) response["role"] = "unknown";
        
        response["succeeded"] = result.Succeeded;
        
        return Ok(response);
    }
        
    [HttpGet]
    public async Task<IActionResult> CurrentUser()
    {
        var user = await userManager.GetUserAsync(User);
        
        if (user == null)
            throw new ApplicationException($"Пользователь не авторизован");
        
        var response = user.ToDTO().ToDictionary();
        
        response["role"] = user.UserRole;
        
        return Ok(response);
    }
    
    [HttpGet]
    public IActionResult From_User_Name([Required] string userName)
    {
        var user = userManager.Users.FirstOrDefault(appUser => appUser.UserName == userName);
        
        if (user == null)
            throw new ApplicationException($"Пользователь не найден");
        
        var response = user.ToDTO().ToDictionary();
        
        response["role"] = user.UserRole;
        
        return Ok(response);
    }
    
    [HttpGet]
    public IActionResult FromId([Required] string userId)
    {
        var user = userManager.Users.FirstOrDefault(appUser => appUser.Id == userId);
        
        if (user == null)
            throw new ApplicationException($"Такого пользователя не существует");
        
        var response = user.ToDTO().ToDictionary();
        
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
