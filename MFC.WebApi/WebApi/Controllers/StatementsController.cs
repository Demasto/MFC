using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using WebApi.CustomActionResult;
using WebApi.Services;
using WebApi.Services.Interfaces;

namespace WebApi.Controllers;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class StatementsController(IStatementService service) : ControllerBase
{
    [HttpGet]
    public IActionResult GetFilesList()
    {
        try
        {
           var filesList = service.GetFilesList();
           return Ok(filesList);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        
    }
    
    [HttpGet("{fileName}")]
    public IActionResult GetFile(string fileName)
    {
        try
        {
            var stream = service.ReadFileStream(fileName);
            return File(stream, "application/octet-stream", fileName);
        }
        catch (Exception e)
        {
            return ExtractActionResult(e);
        }
        
    }


    
    [HttpPost]
    public async Task<IActionResult> CreateFile(IFormFile file)
    {
        if (file.Length == 0)
        {
            return BadRequest("No file uploaded.");
        }
        
        try
        {
            await service.CreateFile(file.FileName, file.OpenReadStream());
            
            return Ok($"File {file.FileName} has been uploaded successfully.");
        }
        catch (Exception e)
        {
            return ExtractActionResult(e);
        }
        
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateFile(IFormFile file)
    {
        if (file.Length == 0)
        {
            return BadRequest("No file uploaded.");
        }
        
        try
        {
            await service.UpdateFile(file.FileName, file.OpenReadStream());
            
            return Ok($"File {file.FileName} has been updated successfully.");
        }
        catch (Exception e)
        {
            return ExtractActionResult(e);
        }
    }
    
    [HttpDelete]
    public IActionResult DeleteFile(string fileName)
    {
        
        try
        {
            service.DeleteFile(fileName);
            
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