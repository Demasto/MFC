using Domain.Entities;

namespace WebApi.Services.Interfaces;

public interface IFileService
{
    public Task<List<string>> GetFilesList();
    public Task AddNewFile(string fileName, Stream stream);
    public Task UpdateFile(string fileName, Stream stream);
    public Task<Statement> LoadFile(string fileName);

    // void SaveFile
}