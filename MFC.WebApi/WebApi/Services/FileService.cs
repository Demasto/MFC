using Domain.Entities;
using WebApi.Services.Interfaces;

namespace WebApi.Services;

public class FileService : IFileService
{
    public FileService()
    {
        SaveDirectory.Restore();
    }
    
    
    public IEnumerable<string> GetFilesList(ServiceType type)
    {
        return SaveDirectory.Files(type);
    }
    
    public async Task CreateFile(string fileName, Stream stream, ServiceType type)
    {

        var path = SaveDirectory.PathToFile(type, fileName);
        
        await CreateOrThrow(path, stream);
    }
    
    public async Task UpdateFile(string fileName, Stream stream, ServiceType type)
    {
        var pathToFile = SaveDirectory.PathToFile(type, fileName);
        
        FindOrThrow(pathToFile);
        
        File.Delete(pathToFile);
        
        await using Stream outStream = File.OpenWrite(pathToFile);
        await stream.CopyToAsync(outStream);
    }
    
    public void DeleteFile(string fileName, ServiceType type)
    {
        var path = SaveDirectory.PathToFile(type, fileName);
        
        FindOrThrow(path);
        
        File.Delete(path);
        
    }
    
    
    public FileStream ReadFileStream(string fileName, ServiceType type)
    {
        var path = SaveDirectory.PathToFile(type, fileName);
        
        FindOrThrow(path);
        
        return File.OpenRead(path);
    }
    
    
    
 
    private static void FindOrThrow(string path)
    {
        if (!File.Exists(path))
            throw new FileNotFoundException("Такого файла не существует!");
    }
    private static async Task CreateOrThrow(string path, Stream stream)
    {
        if (File.Exists(path)) 
            throw new Exception($"Файл {path} уже существует!");
        
        await using var outStream = File.OpenWrite(path);
        await stream.CopyToAsync(outStream);
    }
    
    public static string CopyFile(string path)
    {
        if (!File.Exists(path)) throw new FileNotFoundException();

        var copy = Path.GetTempFileName();
        
        
        File.Copy(path, copy, true);
        Console.WriteLine(copy);
        return copy;
    }
}