using Infrastructure.Identity;
using Infrastructure.Models.DTO;
using Infrastructure.Repo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = Role.Admin)]
public class ServicesController(IServiceRepository serviceRepo) : ControllerBase
{
    [HttpGet]
    public IActionResult GetServices()
    {
        return Ok(serviceRepo.Get());
    }
    
    [HttpPost]
    public IActionResult AddService([FromBody] ServiceDTO serviceDTO)
    {
        
        serviceRepo.Add(serviceDTO);
        return Ok();
    }
    
    [HttpDelete]
    public IActionResult DeleteService(string fileName)
    {
        serviceRepo.Remove(fileName);
        return Ok();
    }
    
    [HttpDelete("clear_dataBase")]
    public IActionResult RemoveAllService()
    {
        serviceRepo.RemoveAll();
        return Ok();
    }
}