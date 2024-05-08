using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Infrastructure.Identity;

namespace WebApi.Controllers.Accounts;

[Authorize]
[Route("api/[controller]/[action]")]
public class UserSettingsController(UserManager<AppUser> userManager) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> ChangeEmail([EmailAddress]string newEmail)
    {
        var user = await userManager.GetUserAsync(User);
        if (user == null) return BadRequest("Пользователь не авторизован");
        var token = await userManager.GenerateChangeEmailTokenAsync(user, newEmail);
        var result = await userManager.ChangeEmailAsync(user, newEmail, token);
        return Ok(result);
    }
    
    [HttpGet]
    public async Task<ActionResult> ChangePassword(string currentPassword, string newPassword)
    {
        var user = await userManager.GetUserAsync(User);
        if (user == null) return BadRequest("Пользователь не авторизован");

 
        var result = await userManager.ChangePasswordAsync(user, currentPassword, newPassword);
        return Ok(result);
    }
    
}