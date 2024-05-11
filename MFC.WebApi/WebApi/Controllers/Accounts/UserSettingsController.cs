using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Domain.Entities.Users;
using WebApi.Filters;

namespace WebApi.Controllers.Accounts;


[CustomExceptionFilter]
[Route("api/[controller]/[action]")]
public class UserSettingsController(UserManager<AppUser> userManager) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> ChangeEmail([EmailAddress]string newEmail)
    {
        var user = await userManager.GetUserAsync(User);
        if (user == null) throw new Exception("Пользователь не авторизован");
        
        var result = await userManager.SetEmailAsync(user, newEmail);
        return Ok(result);
    }
    
    [HttpGet]
    public async Task<ActionResult> ChangePassword(string currentPassword, string newPassword)
    {
        var user = await userManager.GetUserAsync(User);
        if (user == null) throw new Exception("Пользователь не авторизован");

 
        var result = await userManager.ChangePasswordAsync(user, currentPassword, newPassword);
        return Ok(result);
    }
    
}