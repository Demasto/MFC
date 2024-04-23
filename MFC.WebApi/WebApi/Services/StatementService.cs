
using Domain.Entities;
using Infrastructure.Repositories.Interfaces;
using Minio;
using WebApi.Services.Interfaces;

namespace WebApi.Services;

public class StatementService(IStatementRepository repository) : IStatementService
{
    private static readonly string SaveDir = Path.Combine(Directory.GetCurrentDirectory(), "statements");

    private static string PathToFile(string fileName)
    {
        return Path.Combine(SaveDir, fileName);
    }

    private static void CheckSaveDir()
    {
        if (!Directory.Exists(SaveDir))
        {
            Directory.CreateDirectory(SaveDir);
            // TODO удалить все пред файлы в базе?/
        }
    }
    
    
    public async Task<List<string>> GetFilesList()
    { 
        
        if (!Directory.Exists(SaveDir))
        {
            throw new Exception("На данном сервере нет файлов");
        }
  
        
        var statements = await repository.GetAllStatementsAsync();
        
        
        return statements
            .Where(statement => File.Exists(statement.Path))
            .Select(statement => statement.Name)
            .ToList();
    }
    
    public async Task AddNewFile(string fileName, Stream stream)
    {
        CheckSaveDir();
        
        var pathToFile = PathToFile(fileName);
        
        if (File.Exists(pathToFile))
            throw new Exception($"File: {pathToFile} - already exist!");
        
        
        await using Stream outStream = File.OpenWrite(pathToFile);
        await stream.CopyToAsync(outStream);
        
        repository.SaveFile(fileName, pathToFile);
    }
    
    public async Task UpdateFile(string fileName, Stream stream)
    {
        var pathToFile = PathToFile(fileName);
        
        if (!File.Exists(pathToFile))
            throw new Exception($"File: {pathToFile} - doesnt exist!");
        
        // TODO Как синхронизировать базу и локальное хранилище......
        File.Delete(pathToFile);
        
        await using Stream outStream = File.OpenWrite(pathToFile);
        await stream.CopyToAsync(outStream);
    }
    
    public async Task DeleteFile(string fileName)
    {
        
        var pathToFile = PathToFile(fileName);
        
        if (!File.Exists(pathToFile))
            throw new Exception($"File: {pathToFile} - doesnt exist!");
        
        File.Delete(pathToFile);
        
        repository.DeleteFile(1);
    }
    
    
    public async Task<Statement> LoadFile(string fileName)
    {
       return await repository.GetStatementByFileNameAsync(fileName);
    }
}