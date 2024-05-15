using Domain.Entities;
using WebApi.Services.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace WebApi.Services;

public class FileService : IFileService
{
    public FileService()
    {
        SaveDirectory.Restore();
    }
    
    public IEnumerable<string> GetAllFromType(ServiceType type)
    {
        return SaveDirectory.Files(type);
    }
    
    public async Task Create(string fileName, Stream stream, ServiceType type)
    {

        var path = SaveDirectory.PathToFile(type, fileName);
        
        await CreateOrThrow(path, stream);
    }
    public FileStream Read(string fileName, ServiceType type)
    {
        var path = SaveDirectory.PathToFile(type, fileName);
        
        FindOrThrow(path);
        
        return File.OpenRead(path);
    }
    public async Task Update(string fileName, Stream stream, ServiceType type)
    {
        var pathToFile = SaveDirectory.PathToFile(type, fileName);
        
        FindOrThrow(pathToFile);
        
        File.Delete(pathToFile);
        
        await using Stream outStream = File.OpenWrite(pathToFile);
        await stream.CopyToAsync(outStream);
    }
    
    public void Delete(string fileName, ServiceType type)
    {
        var path = SaveDirectory.PathToFile(type, fileName);
        
        FindOrThrow(path);
        
        File.Delete(path);
        
    }

    public string FromServiceName(string serviceName, ServiceType type)
    {
        var files = GetAllFromType(type);
        var fileNameWithExtension = files.FirstOrDefault(fileName => fileName.Contains(serviceName.ToLower()));
        
        if (fileNameWithExtension == null) throw new Exception("Файл не найден");

        return fileNameWithExtension;
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