using Domain.Entities;
using WebApi.Services.Interfaces;

namespace WebApi.Services;

public class StatementService : IStatementService
{
    private readonly SaveDirectory _saveDir = new(ServiceType.StudentStatement);
    public StatementService()
    {
        
    }
    
    public List<string> GetFilesList()
    {
        return _saveDir.Files();
    }
    
    public async Task CreateFile(string fileName, Stream stream)
    {
        var path = _saveDir.PathToFile(fileName);
        
        await FileService.CreateOrThrow(path, stream);
    }
    
    public async Task UpdateFile(string fileName, Stream stream)
    {
        var pathToFile = _saveDir.PathToFile(fileName);
        
        FileService.FindOrThrow(pathToFile);
        
        File.Delete(pathToFile);
        
        await using Stream outStream = File.OpenWrite(pathToFile);
        await stream.CopyToAsync(outStream);
    }
    
    public void DeleteFile(string fileName)
    {
        var path = _saveDir.PathToFile(fileName);
        
        FileService.FindOrThrow(path);
        
        File.Delete(path);
        
    }
    
    
    public FileStream ReadFileStream(string fileName)
    {
        var path = _saveDir.PathToFile(fileName);
        
        FileService.FindOrThrow(path);
        
        return File.OpenRead(path);
    }
}