using Domain.Entities;
using WebApi.Services.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace WebApi.Services;

public class FileService : IFileService
{
    public FileService()
    {
        SaveDirectory.Restore();
        StaticDirectory.Restore();
    }
    
    public IEnumerable<string> GetAllFromType(ServiceType type)
    {
        return SaveDirectory.Files(type);
    }
    
    public async Task Create(string fileName, Stream stream, ServiceType type)
    {

        var path = SaveDirectory.PathToFile(type, fileName);
        
        await CreateOrThrow(path, stream);
        AutoFillDocService.GenerateTemplate(fileName, path);
    }
    public FileStream Read(string fileName, ServiceType type)
    {
        var path = SaveDirectory.PathToFile(type, fileName);
        
        FindOrThrow(path);
        
        return File.OpenRead(path);
    }
    
    public string ReadTemplate(string fileName)
    {
        var path = StaticDirectory.PathToFile(fileName, Dir.Template);
        
        FindOrThrow(path);
        
        return path;
    }
    public async Task Update(string fileName, Stream stream, ServiceType type)
    {
        Delete(fileName, type);
        
        await using Stream outStream = File.OpenWrite(SaveDirectory.PathToFile(type, fileName));
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
        var fileNameWithExtension = files.FirstOrDefault(fileName =>
            fileName.Contains(serviceName, StringComparison.CurrentCultureIgnoreCase));
        
        if (fileNameWithExtension == null) throw new Exception("Файл не найден");

        return fileNameWithExtension;
    }

    public string FromService(Service service)
    {
        return FromServiceName(service.Name, service.Type);
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
    

    
    public static string CreateTempFile(string path)
    {
        if (!File.Exists(path)) throw new FileNotFoundException();

        var copy = Path.GetTempFileName();
        
        
        File.Copy(path, copy, true);
        Console.WriteLine(copy);
        return copy;
    }
}