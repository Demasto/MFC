using System.Net;
using Domain.Models;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Interfaces;
using Infrastructure.Services.Interfaces;

namespace Infrastructure.Services;

public class FileService(IStatementRepository repository) : IFileService
{
    
    public async Task<List<Statement>> GetFilesList()
    {
       return await repository.GetAllStatementsAsync();
    }
    
    public async Task SaveFile(string fileName, Stream stream)
    {
        var pathToFile = Path.Combine(Directory.GetCurrentDirectory(), "downloads", fileName);
        
        await using Stream outStream = File.OpenWrite(pathToFile);
        await stream.CopyToAsync(outStream);
        
        repository.SaveFile(fileName, pathToFile);
    }
    
    
    public async Task<Statement> LoadFile(string fileName)
    {
       return await repository.GetStatementByFileNameAsync(fileName);
    }
}