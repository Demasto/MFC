using Domain.Entities;

namespace WebApi.Services.Interfaces;

public interface IStatementService
{
    public Task<List<string>> GetFilesList();
    public Task AddNewFile(string fileName, Stream stream);
    public Task UpdateFile(string fileName, Stream stream);
    public Task<Statement> LoadFile(string fileName);
    public Task DeleteFile(string fileName);

    // void SaveFile
}