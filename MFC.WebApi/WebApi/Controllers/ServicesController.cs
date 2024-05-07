using Infrastructure.Models.DTO;
using Infrastructure.Repo;

using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ServicesController(IServiceRepository serviceRepo) : ControllerBase
{
    [HttpGet]
    public IActionResult GetServices()
    {
        return Ok(serviceRepo.Get());
    }
    
    [HttpPost]
    public IActionResult AddService([FromBody] ServiceDTO service, IFormFile file)
    {
        serviceRepo.Add(service);
        return Ok();
    }
    
    [HttpDelete]
    public IActionResult DeleteService(string fileName)
    {
        serviceRepo.Remove(fileName);
        return Ok();
    }
}