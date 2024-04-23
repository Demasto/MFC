using Minio;
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
    public async Task<IActionResult> GetFilesList()
    {
        try
        {
           var filesList = await service.GetFilesList();
           return Ok(filesList);
        }
        catch (Exception e)
        {
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
            await service.AddNewFile(file.FileName, file.OpenReadStream());
            
            return Ok($"File {file.FileName} has been uploaded successfully.");
        }
        catch (Exception e)
        {
            return BadRequest(e);
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
            return BadRequest(e);
        }
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteFile(string fileName)
    {
        
        try
        {
            await service.DeleteFile(fileName);
            
            return Ok($"File {fileName} has been deleted successfully.");
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }
}