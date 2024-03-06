using WebApi.Services.Interfaces;

namespace WebApi.Controllers;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class StatementsController(IFileService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllFiles()
    {
        var filesList = await service.GetFilesList();
        
        return Ok(filesList);
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
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
        
        return Ok($"File {file.FileName} has been uploaded successfully.");
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
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }

        return Ok($"File {file.FileName} has been updated successfully.");
    }
}