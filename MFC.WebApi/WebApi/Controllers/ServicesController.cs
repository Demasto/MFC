using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Infrastructure.Repo;

using Domain.Entities;
using Domain.DTO;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ServicesController(IServiceRepository serviceRepo) : ControllerBase
{
    [HttpGet]
    public IActionResult GetServices()
    {
        return Ok(serviceRepo.GetAll());
    }
    
    [HttpGet("{serviceName}")]
    public IActionResult Get(string serviceName)
    {
        return Ok(serviceRepo.Get(serviceName));
    }
    
    [Authorize(Roles = Role.Admin)]
    [HttpPost]
    public IActionResult AddService([FromBody] ServiceDTO serviceDTO)
    {
        
        serviceRepo.Add(serviceDTO);
        return Ok();
    }
    
    [Authorize(Roles = Role.Admin)]
    [HttpPut("switch_state/{serviceName}")]
    public IActionResult SwitchState(string serviceName)
    {
        var response = new Dictionary<string, bool>
        {
            ["succeeded"] = true,
            ["current_state"] = serviceRepo.Switch(serviceName)
        };

        return Ok(response);
    }
    
    [Authorize(Roles = Role.Admin)]
    [HttpDelete("{serviceName}")]
    public IActionResult DeleteService(string serviceName)
    {
        serviceRepo.Remove(serviceName);
        return Ok();
    }
    
    [Authorize(Roles = Role.Admin)]
    [HttpDelete("clear_dataBase")]
    public IActionResult RemoveAllService()
    {
        serviceRepo.RemoveAll();
        return Ok();
    }
}