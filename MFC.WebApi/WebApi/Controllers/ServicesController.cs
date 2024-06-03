using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Domain.Entities;
using Domain.DTO;

using Infrastructure.Repo;

using WebApi.CustomActionResult;
using WebApi.Filters;
using WebApi.Services;
using WebApi.Services.Interfaces;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[CustomExceptionFilter]
[Authorize(Roles = Role.Admin)]
public class ServicesController(IServiceRepository serviceRepo, IFileService fileService) : ControllerBase
{

    [HttpGet]
    [AllowAnonymous]
    public IActionResult GetAll()
    {
        var response = ApiResults.Ok("services", serviceRepo.GetAll()) ;
        return Ok(response);
    }
    
    [AllowAnonymous]
    [HttpGet("type/{type}")]
    public IActionResult GetFromType(ServiceType type)
    {
        var filesList = fileService.GetAllFromType(type);
        return Ok(filesList);
    }
    
    [AllowAnonymous]
    [HttpGet("{serviceName}")]
    public IActionResult Get(string serviceName)
    {
        var response = ApiResults.Ok("service", serviceRepo.Get(serviceName));
        return Ok(response);
    }
    
    [AllowAnonymous]
    [HttpGet("file/{serviceName}")]
    public FileStreamResult GetFile(string serviceName)
    {
        var service = serviceRepo.Get(serviceName);
        var fileName = fileService.FromServiceName(service.Name, service.Type);
        
        var stream = fileService.Read(fileName.ToLower(), service.Type);
        return File(stream, "application/octet-stream", fileName);
    }
    
    [AllowAnonymous]
    [HttpGet("template/{serviceName}")]
    public IActionResult GetTemplate(string serviceName)
    {
        var service = serviceRepo.Get(serviceName);
        var fileName = fileService.FromServiceName(service.Name, service.Type);
        
        return Ok(ApiResults.Ok("link", CreateLink(fileName)));
    }
    private string CreateLink(string name)
    {
        var s = Request.IsHttps ? "s" : "";
        return $"http{s}://{Request.Host}/template/{name}";
    }

    [HttpPost("with_file")]
    public async Task<IActionResult> AddService([FromForm] ServiceWithFileDTO service)
    {
        serviceRepo.Add(service);
        
        await fileService.Create(service.File.FileName, service.File.OpenReadStream(), service.Type);
        
        return Ok(ApiResults.Ok());
    }
    
    [HttpPost]
    public IActionResult AddService([FromForm] ServiceDTO service)
    {
        if(service.Type is not ServiceType.TransferAndReinstatement)
            return Ok(ApiResults.Bad($"Услуга с типом {service.Type} должна загружаться с файлом"));
        
        serviceRepo.Add(service);
        return Ok(ApiResults.Ok());
    }
  
    
    [HttpPut]
    public IActionResult UpdateService([FromForm] UpdateServiceDTO serviceDTO)
    {
        serviceRepo.Update(serviceDTO);
        return Ok(ApiResults.Ok());
    }
    
    
    [HttpPut("file")]
    public async Task<IActionResult> UpdateServiceFile([FromForm] ServiceWithFileDTO service)
    {
        await fileService.Update(service.File.FileName, service.File.OpenReadStream(), service.Type);
        return Ok(ApiResults.Ok());
    }
    
    [HttpPut("switch_state/{serviceName}")]
    public IActionResult SwitchState(string serviceName)
    {
        return Ok(ApiResults.Ok("current_state", serviceRepo.Switch(serviceName)));
    }
    
    [HttpDelete("{serviceName}")]
    public IActionResult DeleteService(string serviceName)
    {
        var removed = serviceRepo.Remove(serviceName);
        
        var fileName = fileService.FromService(removed);
        fileService.Delete(fileName, removed.Type);
        
        return Ok(ApiResults.Ok());
    }
    
    [HttpDelete("clear_all")]
    public IActionResult RemoveAllService(string? password)
    {
        if (password != "0123")
            return Ok(ApiResults.Bad("Для безвозвратного удаления услуг со ВСЕМИ файлами необходимо ввести пароль. (0123)"));
        
        serviceRepo.RemoveAll();
        SaveDirectory.DeleteAll();
        return Ok(ApiResults.Ok());
    }
}