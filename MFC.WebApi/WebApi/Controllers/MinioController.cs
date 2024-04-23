// using System.Reactive.Linq;
// using Microsoft.AspNetCore.Mvc;
// using Minio;
// using Minio.DataModel.Args;
//
// namespace WebApi.Controllers;
//
// // [Route("api/[controller]")]
// // [ApiController]
// public class MinioController(IMinioClient minioClient) : ControllerBase
// {
//     //     
//     // [HttpGet("{fileName}")]
//     // [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
//     public async Task<IActionResult> GetUrl(string bucketId = "example", string fileName = "test")
//     {
//         var exist = await minioClient.BucketExistsAsync(new BucketExistsArgs().WithBucket(bucketId));
//         if (!exist) return BadRequest("BucketExistsError");
//
//        
//         
//         // var a = await minioClient.GetObjectAsync(new GetObjectArgs()
//         //     .WithBucket(bucketId)
//         //     .WithObject(fileName)
//         //     .WithCallbackStream(stream =>
//         //     {
//         //         Console.WriteLine(stream.Length);
//         //     })
//         // );
//         // Console.WriteLine(a);
//         
//         return Ok(await minioClient
//             .PresignedGetObjectAsync( new PresignedGetObjectArgs()
//                 .WithBucket(bucketId)
//                 .WithObject(fileName).WithExpiry(60)
//             )
//             
//         );
//     }
//     
//     public async Task<IActionResult> Get(string bucket = "example")
//     {
//         ListObjectsArgs options = new();
//         options.WithBucket(bucket);
//         options.WithRecursive(true);
//             
//         return Ok(await minioClient.ListBucketsAsync(new CancellationToken(false)));
//     }
//
//     // [HttpPost]
//     public async Task<IActionResult> SaveFile(IFormFile file, string bucketId = "example")
//     {
//         if (file.Length < 0)
//             return BadRequest();
//         
//         Console.Write(file.FileName);
//
//         return Ok(await minioClient
//             .PutObjectAsync( new PutObjectArgs()
//                 .WithBucket(bucketId)
//                 .WithObject(file.FileName)
//                 .WithStreamData(file.OpenReadStream())
//                 .WithObjectSize(file.Length)
//                 .WithContentType(file.ContentType)
//             )
//             
//         );
//     }
// }