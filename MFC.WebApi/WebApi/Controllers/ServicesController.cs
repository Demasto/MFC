using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Infrastructure.Repo;

using Domain.Entities;
using Domain.DTO;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
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
    [HttpDelete]
    public IActionResult DeleteService(string fileName)
    {
        serviceRepo.Remove(fileName);
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