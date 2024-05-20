namespace WebApi.Services;


public static class StaticDirectory
{
    public static readonly string RootSaveDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
    
    public static string PathToFile(string name)
    {
        return Path.Combine(RootSaveDir, name);
    }
    
    
    public static bool IsExist(string inn)
    {
        return File.Exists(PathToFile(inn));
    }
    
    public static string CopyFile(string source, string tempName)
    {
        if (!File.Exists(source)) throw new FileNotFoundException();
        
        var dest = PathToFile(tempName);
        
        File.Copy(source, dest, true);
        
        return dest; 
    }
}