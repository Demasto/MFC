using Domain.Models;
using Infrastructure.Services;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

namespace WebApi.Controllers;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class UploadController(IFileService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllFiles()
    {
        await service.GetFilesList();
        
        return Ok($"successfully.");
    }
    
    [HttpPost]
    public async Task<IActionResult> UploadFile(IFormFile file)
    {
        if (file.Length == 0)
        {
            return BadRequest("No file uploaded.");
        }
        
        try
        {
            await service.SaveFile(file.FileName, file.OpenReadStream());
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
        
        var path = Path.Combine(Directory.GetCurrentDirectory(), "uploads", file.FileName);

        try
        {
            await using var stream = new FileStream(path, FileMode.Create);
            await file.CopyToAsync(stream);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        return Ok($"File {file.FileName} has been updated successfully.");
    }
}