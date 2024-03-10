
using Domain.Entities;
using Infrastructure.Repositories.Interfaces;

using WebApi.Services.Interfaces;

namespace WebApi.Services;

public class FileService(IStatementRepository repository) : IFileService
{
    private static readonly string SaveDir = Path.Combine(Directory.GetCurrentDirectory(), "statements");
 
    public async Task<List<string>> GetFilesList()
    { 
        
        if (!Directory.Exists(SaveDir))
        {
            throw new Exception("Files doesnt exist");
        }

        
        var statements = await repository.GetAllStatementsAsync();
        
        return statements
            .Where(statement => File.Exists(statement.FilePath))
            .Select(statement => statement.FileName)
            .ToList();
    }
    
    public async Task AddNewFile(string fileName, Stream stream)
    {
        if (!Directory.Exists(SaveDir))
        {
            Directory.CreateDirectory(SaveDir);
            // TODO удалить все пред файлы в базе?/
        }
        
        var pathToFile = Path.Combine(SaveDir, fileName);
        
        if (File.Exists(pathToFile))
        {
            throw new Exception($"File: {pathToFile} - already exist!");
        }
        
        await using Stream outStream = File.OpenWrite(pathToFile);
        await stream.CopyToAsync(outStream);
        
        repository.SaveFile(fileName, pathToFile);
    }
    
    public async Task UpdateFile(string fileName, Stream stream)
    {
        var pathToFile = Path.Combine(Directory.GetCurrentDirectory(), "statements", fileName);
        
        if (!File.Exists(pathToFile))
        {
            throw new Exception($"File: {pathToFile} - doesnt exist!");
        }
        File.Delete(pathToFile);
        
        await using Stream outStream = File.OpenWrite(pathToFile);
        await stream.CopyToAsync(outStream);
    }
    
    
    public async Task<Statement> LoadFile(string fileName)
    {
       return await repository.GetStatementByFileNameAsync(fileName);
    }
}