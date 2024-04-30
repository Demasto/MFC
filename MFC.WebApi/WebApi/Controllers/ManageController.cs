using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class ManageController(
        UserManager<Student> userManager, 
        SignInManager<Student> signInManager) : Controller
    {




        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Index(IndexViewModel model)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return View(model);
        //     }
        //
        //     var user = await _userManager.GetUserAsync(User);
        //     if (user == null)
        //     {
        //         throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
        //     }
        //
        //     var email = user.Email;
        //     if (model.Email != email)
        //     {
        //         var setEmailResult = await _userManager.SetEmailAsync(user, model.Email);
        //         if (!setEmailResult.Succeeded)
        //         {
        //             throw new ApplicationException($"Unexpected error occurred setting email for user with ID '{user.Id}'.");
        //         }
        //     }
        //
        //     var phoneNumber = user.PhoneNumber;
        //     if (model.PhoneNumber != phoneNumber)
        //     {
        //         var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, model.PhoneNumber);
        //         if (!setPhoneResult.Succeeded)
        //         {
        //             throw new ApplicationException($"Unexpected error occurred setting phone number for user with ID '{user.Id}'.");
        //         }
        //     }
        //
        //     StatusMessage = "Your profile has been updated";
        //     return RedirectToAction(nameof(Index));
        // }



        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return View(model);
        //     }
        //
        //     var user = await _userManager.GetUserAsync(User);
        //     if (user == null)
        //     {
        //         throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
        //     }
        //
        //     var changePasswordResult = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
        //     if (!changePasswordResult.Succeeded)
        //     {
        //         AddErrors(changePasswordResult);
        //         return View(model);
        //     }
        //
        //     await _signInManager.SignInAsync(user, isPersistent: false);
        //     _logger.LogInformation("User changed their password successfully.");
        //     StatusMessage = "Your password has been changed.";
        //
        //     return RedirectToAction(nameof(ChangePassword));
        // }

       

        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> SetPassword(SetPasswordViewModel model)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return View(model);
        //     }
        //
        //     var user = await _userManager.GetUserAsync(User);
        //     if (user == null)
        //     {
        //         throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
        //     }
        //
        //     var addPasswordResult = await _userManager.AddPasswordAsync(user, model.NewPassword);
        //     if (!addPasswordResult.Succeeded)
        //     {
        //         AddErrors(addPasswordResult);
        //         return View(model);
        //     }
        //
        //     await _signInManager.SignInAsync(user, isPersistent: false);
        //     StatusMessage = "Your password has been set.";
        //
        //     return RedirectToAction(nameof(SetPassword));
        // }

    }
}