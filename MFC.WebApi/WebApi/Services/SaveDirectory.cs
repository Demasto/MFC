using Domain.Entities;

namespace WebApi.Services;

public static class SaveDirectory
{
    private static readonly string RootSaveDir = Path.Combine(Directory.GetCurrentDirectory(), "files");

    public static void DeleteAll()
    {
        Directory.Delete(RootSaveDir, true);
    }
    private static string SaveDirPath(this ServiceType type)
    {
        return Path.Combine(RootSaveDir, ServiceDir.Dict[type]);
    }
    
    public static string PathToFile(ServiceType serviceType, string fileName)
    {
        return Path.Combine(serviceType.SaveDirPath(), fileName);
    }
    
    public static void Restore()
    {
        var notExistedDirs = ServiceDir.Dict.Keys
            .Select(SaveDirPath)
            .Where(path => !Directory.Exists(path));
   
        foreach (var path in notExistedDirs)
        {
            Directory.CreateDirectory(path);
        }
    }

    
    public static IEnumerable<string> Files(ServiceType type)
    {
        return Directory
            .GetFiles(SaveDirPath(type))
            .Select(ExtractFileName);
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