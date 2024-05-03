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
            if (e.GetType() == typeof(FileNotFoundException))
            {
                
                return NotFound(e.Message);
            }
            return BadRequest(e.Message);
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
            if (e.GetType() == typeof(FileNotFoundException))
            {
                return NotFound(e.Message);
            }
            return BadRequest(e.Message);
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
            return BadRequest(e.Message);
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
            if (e.GetType() == typeof(FileNotFoundException))
            {
                return NotFound(e.Message);
            }
            return BadRequest(e.Message);
        }
    }
}