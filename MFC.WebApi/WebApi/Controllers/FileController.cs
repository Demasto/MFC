using Microsoft.AspNetCore.Mvc;

using Domain.Entities;
using WebApi.Services.Interfaces;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FileController(IFileService service) : ControllerBase
{
    [HttpGet]
    public IActionResult GetFilesList(ServiceType type)
    {
        try
        {
           var filesList = service.GetFilesList(type);
           return Ok(filesList);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        
    }
    
    [HttpGet("{fileName}")]
    public IActionResult GetFile(string fileName, ServiceType type)
    {
        try
        {
            var stream = service.ReadFileStream(fileName, type);
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
            await service.CreateFile(file.FileName, file.OpenReadStream(), type);
            
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
            await service.UpdateFile(file.FileName, file.OpenReadStream(), type);
            
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
            service.DeleteFile(fileName, type);
            
            return Ok($"File {fileName} has been deleted successfully.");
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