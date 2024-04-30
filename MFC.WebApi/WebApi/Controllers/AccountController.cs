using System.Dynamic;
using System.Text.Json;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    public class AccountController(
        UserManager<AppUser> userManager, 
        SignInManager<AppUser> signInManager) : Controller
    {

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string userName = "admin", string password = "admin123")
        {
            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, set lockoutOnFailure: true
            var result = await signInManager.PasswordSignInAsync(userName, password, true, lockoutOnFailure: false);
            
            return Ok(result.Succeeded);
        }
        
        [HttpGet]
        public async Task<IActionResult> CurrentUser()
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
            }
            
            var response = user.ToStudent().ToDictionary();
            
            response["Roles"] = await userManager.GetRolesAsync(user);

            return Ok(response);
        }
        

        
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            Console.WriteLine("User logged out.");
            return Ok();
        }
        
        // [HttpPost]
        // [AllowAnonymous]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
        // {
        //
        //     var user = new Student { UserName = model.Email, Email = model.Email };
        //     var result = await _userManager.CreateAsync(user, model.Password);
        //     if (result.Succeeded)
        //     {
        //         _logger.LogInformation("User created a new account with password.");
        //
        //         var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        //             
        //             
        //         /*Отправить код клиенту через Email сервис, но мы упрощаем:*/
        //             
        //             
        //         await _userManager.ConfirmEmailAsync(user, code);
        //
        //         await _signInManager.SignInAsync(user, isPersistent: false);
        //         _logger.LogInformation("User created a new account with password.");
        //         return RedirectToLocal(returnUrl);
        //     }
        //     AddErrors(result);
        //
        //     // If we got this far, something failed, redisplay form
        //     return View(model);
        // }
        
    }
}