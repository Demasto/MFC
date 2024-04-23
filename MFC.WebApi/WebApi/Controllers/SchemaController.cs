using Microsoft.AspNetCore.Mvc;
using WebApi.Services.Interfaces;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SchemaController(IStatementService service) : ControllerBase
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
}