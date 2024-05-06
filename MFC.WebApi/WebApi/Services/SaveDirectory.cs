using Domain.Entities;

namespace WebApi.Services;

public static class SaveDirectory
{
    private static readonly string RootSaveDir = Path.Combine(Directory.GetCurrentDirectory(), "files");

    private static string SaveDirPath(ServiceType serviceType)
    {
        return Path.Combine(RootSaveDir, ServiceDir.Dict[serviceType]);
    }
    public static string PathToFile(ServiceType serviceType, string fileName)
    {
        return Path.Combine(SaveDirPath(serviceType), fileName);
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