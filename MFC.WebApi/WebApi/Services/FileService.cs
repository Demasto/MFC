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
    public static async void CreateOrThrow(string path, Stream stream)
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
public class SaveDirectory(string dirName)
{
    private readonly string _path = Path.Combine(Directory.GetCurrentDirectory(), dirName);
    
    public void CheckDir()
    {
        if (Directory.Exists(_path)) return;
        Directory.CreateDirectory(_path);
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