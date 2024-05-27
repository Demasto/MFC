using Domain.Entities;

namespace WebApi.Services;

public enum Dir
{
    Auto,
    Template,
}



public static class StaticDirectory
{
    private static readonly string RootDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
    private static readonly string AutoDir = Path.Combine(RootDir, "auto");
    private static readonly string TemplateDir = Path.Combine(RootDir, "template");
    
    public static void Restore()
    {
        if (!Directory.Exists(AutoDir))
            Directory.CreateDirectory(AutoDir);
        
        if (!Directory.Exists(TemplateDir))
            Directory.CreateDirectory(TemplateDir);
        
    }

    public static string PathToFile(string name, Dir dir)
    {
        return dir switch
        {
            Dir.Auto => Path.Combine(AutoDir, name),
            Dir.Template => Path.Combine(TemplateDir, name),
            _ => throw new ArgumentOutOfRangeException(nameof(dir), dir, null)
        };
    }
    
    
    public static bool IsExist(string name, Dir dir)
    {
        return File.Exists(PathToFile(name, dir));
    }
    
    public static string CopyFile(string source, string tempName, Dir dir)
    {
        if (!File.Exists(source)) throw new FileNotFoundException();
        
        var dest = PathToFile(tempName, dir);
        
        File.Copy(source, dest, true);
        
        return dest; 
    }
}