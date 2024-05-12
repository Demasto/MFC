using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Infrastructure.Repo;

using Domain.Entities;
using Domain.DTO;
using WebApi.CustomActionResult;
using WebApi.Filters;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[CustomExceptionFilter]
public class ServicesController(IServiceRepository serviceRepo) : ControllerBase
{

    [HttpGet]
    public IActionResult GetServices()
    {
        var response = ApiResults.Ok("services", serviceRepo.GetAll()) ;
        return Ok(response);
    }
    
    [HttpGet("{serviceName}")]
    public IActionResult Get(string serviceName)
    {
        var response = ApiResults.Ok("service", serviceRepo.Get(serviceName));
        return Ok(response);
    }
    
    [Authorize(Roles = Role.Admin)]
    [HttpPost]
    public IActionResult AddService([FromBody] ServiceDTO serviceDTO)
    {
        serviceRepo.Add(serviceDTO);
        return Ok(ApiResults.Ok());
    }
    
    [Authorize(Roles = Role.Admin)]
    [HttpPut]
    public IActionResult UpdateService([FromBody] UpdateServiceDTO serviceDTO)
    {
        serviceRepo.Update(serviceDTO);
        return Ok(ApiResults.Ok());
    }
    
    [Authorize(Roles = Role.Admin)]
    [HttpPut("switch_state/{serviceName}")]
    public IActionResult SwitchState(string serviceName)
    {
        var response = ApiResults.Ok("current_state", serviceRepo.Switch(serviceName));
        return Ok(response);
    }
    
    [Authorize(Roles = Role.Admin)]
    [HttpDelete("{serviceName}")]
    public IActionResult DeleteService(string serviceName)
    {
        serviceRepo.Remove(serviceName);
        return Ok(ApiResults.Ok());
    }
    
    [Authorize(Roles = Role.Admin)]
    [HttpDelete("clear_dataBase")]
    public IActionResult RemoveAllService()
    {
        serviceRepo.RemoveAll();
        return Ok(ApiResults.Ok());
    }
}