using Domain.Models;

namespace Infrastructure.Services.Interfaces;

public interface IFileService
{
    public Task<List<Statement>> GetFilesList();
    public Task SaveFile(string fileName, Stream stream);
    public Task<Statement> LoadFile(string fileName);

    // void SaveFile
}