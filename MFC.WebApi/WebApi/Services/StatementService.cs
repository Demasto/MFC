using WebApi.Services.Interfaces;

namespace WebApi.Services;

public static class SaveDirectory
{
    private static readonly string Path = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "statements");
    
    public static void CheckDir()
    {
        if (Directory.Exists(Path)) return;
        Directory.CreateDirectory(Path);
    }
    
    public static string PathToFile(string fileName)
    {
        return System.IO.Path.Combine(Path, fileName);
    }
    
    public static List<string> Files()
    {
        return Directory
            .GetFiles(Path)
            .Select(ExtractFileName)
            .ToList();
    }
    

    public static void CanReadOrThrow(string fileName)
    {
        var path = PathToFile(fileName);
        
        if (!File.Exists(path))
            throw new FileNotFoundException("Такого файла не существует!");
    }
    public static void CanWriteOrThrow(string fileName)
    {
        var path = PathToFile(fileName);
        
        if (File.Exists(path)) 
            throw new Exception($"Файл {fileName} уже существует!");
    }
    
    private static string ExtractFileName(string path)
    {
        return path.Split('\\').Last();
    }
}
public class StatementService : IStatementService
{
    public StatementService()
    {
        SaveDirectory.CheckDir();
    }
    
    public List<string> GetFilesList()
    {
        return SaveDirectory.Files();
    }
    
    public async Task CreateFile(string fileName, Stream stream)
    {
        SaveDirectory.CanWriteOrThrow(fileName);
        await using var outStream = File.OpenWrite(SaveDirectory.PathToFile(fileName));
        await stream.CopyToAsync(outStream);
    }
    
    public async Task UpdateFile(string fileName, Stream stream)
    {
        var pathToFile = SaveDirectory.PathToFile(fileName);
        
        SaveDirectory.CanReadOrThrow(fileName);
        
        File.Delete(pathToFile);
        
        await using Stream outStream = File.OpenWrite(pathToFile);
        await stream.CopyToAsync(outStream);
    }
    
    public void DeleteFile(string fileName)
    {
        
        SaveDirectory.CanReadOrThrow(fileName);
        
        File.Delete(SaveDirectory.PathToFile(fileName));
        
    }
    
    
    public FileStream ReadFileStream(string fileName)
    {
        SaveDirectory.CanReadOrThrow(fileName);
        
        return File.OpenRead(SaveDirectory.PathToFile(fileName));
    }
}