using Microsoft.AspNetCore.Mvc;


namespace WebApi.CustomActionResult;

public class TempFileStreamResult : FileStreamResult
{
    private readonly string _pathToFile;

    private TempFileStreamResult(Stream stream, string contentType, string pathToFile)
        : base(stream, contentType)
    {
        _pathToFile = pathToFile;
    }

    public override async  Task ExecuteResultAsync(ActionContext context)
    {
        try {
            await base.ExecuteResultAsync(context);
        }
        finally {
            System.IO.File.Delete(_pathToFile);
        }
    }
    
    public static TempFileStreamResult File(Stream fileStream, string contentType, string fileDownloadName, string pathToFile)
        => new (fileStream, contentType, pathToFile) { FileDownloadName = fileDownloadName};
}