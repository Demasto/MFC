using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Domain.Entities;
using WebApi.Services;
using WebApi.Services.Interfaces;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = Role.Admin)]
public class FileController(IFileService service) : ControllerBase
{
    
    [HttpGet("{type}")]
    public IActionResult GetFromType(ServiceType type)
    {
        try
        {
            var filesList = service.GetAllFromType(type);
            return Ok(filesList);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet("{type}/{fileName}")]
    public IActionResult GetFromName(string fileName, ServiceType type)
    {
        try
        {
            var stream = service.Read(fileName.ToLower(), type);
            return File(stream, "application/octet-stream", fileName);
        }
        catch (Exception e)
        {
            return ExtractActionResult(e);
        }
        
    }


    
    [HttpPost]
    public async Task<IActionResult> CreateFile(IFormFile file, ServiceType type)
    {
        if (file.Length == 0)
        {
            return BadRequest("No file uploaded.");
        }
        
        try
        {
            await service.Create(file.FileName.ToLower(), file.OpenReadStream(), type);
            
            return Ok($"File {file.FileName} has been uploaded successfully.");
        }
        catch (Exception e)
        {
            return ExtractActionResult(e);
        }
        
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateFile(IFormFile file, ServiceType type)
    {
        if (file.Length == 0)
        {
            return BadRequest("No file uploaded.");
        }
        
        try
        {
            await service.Update(file.FileName.ToLower(), file.OpenReadStream(), type);
            
            return Ok($"File {file.FileName} has been updated successfully.");
        }
        catch (Exception e)
        {
            return ExtractActionResult(e);
        }
    }
    
    [HttpDelete]
    public IActionResult DeleteFile(string fileName, ServiceType type)
    {
        
        try
        {
            service.Delete(fileName.ToLower(), type);
            
            return Ok($"File {fileName} has been deleted successfully.");
        }
        catch (Exception e)
        {
            return ExtractActionResult(e);
        }
    }
    
    [HttpDelete("all")]
    public IActionResult DeleteAll()
    {
        
        try
        {
            SaveDirectory.DeleteAll();
            
            return Ok();
        }
        catch (Exception e)
        {
            return ExtractActionResult(e);
        }
    }
    
    private IActionResult ExtractActionResult(Exception e)
    {
        if (e.GetType() == typeof(FileNotFoundException))
        {
            return NotFound(e.Message);
        }
        return BadRequest(e.Message);
    }

}