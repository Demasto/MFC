// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Authorization;
//
// using Domain.Entities;
// using Microsoft.Extensions.Caching.Distributed;
// using WebApi.CustomActionResult;
// using WebApi.Filters;
// using WebApi.Services;
// using WebApi.Services.Interfaces;
//
// namespace WebApi.Controllers;
//
// [Route("api/[controller]")]
// [ApiController]
// [Authorize(Roles = Role.Admin)]
// [CustomExceptionFilter]
// public class FileController(IFileService service) : ControllerBase
// {
//     // [HttpPost("cache")]
//     // public IActionResult Cache()
//     // {
//     //     cache.SetString("key", "value", 
//     //         new DistributedCacheEntryOptions() {AbsoluteExpirationRelativeToNow = new TimeSpan(0,0,1,0)}
//     //     );
//     //     return Ok();
//     // }
//     //
//     // [HttpGet("cache")]
//     // public IActionResult GetCache()
//     // {
//     //     var result = cache.GetString("key") ?? "no_cache";
//     //     return Ok(result);
//     // }
//     //
//     [HttpGet("{type}")]
//     public IActionResult GetFromType(ServiceType type)
//     {
//         var filesList = service.GetAllFromType(type);
//         return Ok(filesList);
//     }
//     
//     [HttpGet("{type}/{fileName}")]
//     public IActionResult GetFromName(string fileName, ServiceType type)
//     {
//         var stream = service.Read(fileName.ToLower(), type);
//         return File(stream, "application/octet-stream", fileName);
//     }
//     
//     [HttpPost]
//     public async Task<IActionResult> CreateFile(IFormFile file, ServiceType type)
//     {
//         if (file.Length == 0)
//         {
//             throw new Exception("No file uploaded.");
//         }
//         
//         await service.Create(file.FileName.ToLower(), file.OpenReadStream(), type);
//             
//         return Ok($"File {file.FileName} has been uploaded successfully.");
//     }
//     
//     [HttpPut]
//     public async Task<IActionResult> UpdateFile(IFormFile file, ServiceType type)
//     {
//         if (file.Length == 0)
//         {
//             throw new Exception("No file uploaded.");
//         }
//         
//         await service.Update(file.FileName.ToLower(), file.OpenReadStream(), type);
//             
//         return Ok($"File {file.FileName} has been updated successfully.");
//     }
//     
//     [HttpDelete]
//     public IActionResult DeleteFile(string fileName, ServiceType type)
//     {
//         service.Delete(fileName.ToLower(), type);
//             
//         return Ok($"File {fileName} has been deleted successfully.");
//     }
//     
//     [HttpDelete("all")]
//     public IActionResult DeleteAll()
//     {
//         
//
//         SaveDirectory.DeleteAll();
//             
//         return Ok(ApiResults.Ok());
//  
//     }
// }