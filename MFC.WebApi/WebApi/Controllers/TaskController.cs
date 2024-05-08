using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Infrastructure.Repo;
using Domain.Entities.Users;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class TaskController(UserManager<AppUser> userManager, IServiceRepository serviceRepo) : ControllerBase
{
    // [HttpGet("{serviceName}")]
    // public async Task<IActionResult> GetFromType(string serviceName)
    // {
    //     var currentId = userManager.GetUserId(User);
    //     if (currentId == null) throw new ApplicationException($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
    //
    //     var service = serviceRepo.Get(serviceName);
    //     var task = new Domain.Entities.Task()
    //     {
    //         UserId = currentId,
    //         ServiceName = service.Name,
    //         
    //     };
    // }
}