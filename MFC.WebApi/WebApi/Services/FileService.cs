using Domain.Entities;

namespace WebApi.Services;

public static class FileService
{
    public static string PathToFile(string fileName, string dirName)
    {
        var dir = Path.Combine(Directory.GetCurrentDirectory(), dirName);
        return  Path.Combine(dir, fileName);
    }
    public static void FindOrThrow(string path)
    {
        if (!File.Exists(path))
            throw new FileNotFoundException("Такого файла не существует!");
    }
    public static async Task CreateOrThrow(string path, Stream stream)
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
public class SaveDirectory(ServiceType serviceType)
{
    private static readonly string SaveDir = Path.Combine(Directory.GetCurrentDirectory(), "files");
    private readonly string _path = Path.Combine(SaveDir, ServiceDir.Dict[serviceType]);
    
    public static void Restore()
    {
        foreach (var (key, value) in ServiceDir.Dict)
        {
            RestoreDir(value);
        }
    }

    private static void RestoreDir(string dirName)
    {
        var path = Path.Combine(SaveDir, dirName);

        if (Directory.Exists(path)) return;

        Directory.CreateDirectory(path);
    }

    public string PathToFile(string fileName)
    {
        return Path.Combine(_path, fileName);
    }
    
    public List<string> Files()
    {
        return Directory
            .GetFiles(_path)
            .Select(ExtractFileName)
            .ToList();
    }
    
    
    private static string ExtractFileName(string path)
    {
        if (path.Contains('\\'))
        {
            return path.Split('\\').Last();
        }
        if (path.Contains('/'))
        {
            return path.Split('/').Last();
        }

        return path;

    }

}