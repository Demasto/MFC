
using Domain.Entities;
using Infrastructure.Repositories.Interfaces;

using WebApi.Services.Interfaces;

namespace WebApi.Services;

public class FileService(IStatementRepository repository) : IFileService
{
    
    public async Task<Dictionary<string, Stream>> GetFilesList()
    { 
        var statements = await repository.GetAllStatementsAsync();
        var filesList = new Dictionary<string, Stream>();
        
        foreach (var statement in statements.Where(statement => File.Exists(statement.FilePath)))
        {
            await using Stream fileStream = File.OpenRead(statement.FilePath);
            filesList.Add(statement.FileName, fileStream);
        }
        
        //TODO необходимо создать внешний вид каждого документа с помощью ItextPDF

        return filesList;
    }
    
    public async Task AddNewFile(string fileName, Stream stream)
    {
        var pathToFile = Path.Combine(Directory.GetCurrentDirectory(), "downloads", fileName);
        
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
        var pathToFile = Path.Combine(Directory.GetCurrentDirectory(), "downloads", fileName);
        
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