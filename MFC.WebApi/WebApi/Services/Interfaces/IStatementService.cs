using Domain.Entities;

namespace WebApi.Services.Interfaces;

public interface IStatementService
{
    public List<string> GetFilesList();
    public Task CreateFile(string fileName, Stream stream);
    public Task UpdateFile(string fileName, Stream stream);
    public FileStream ReadFileStream(string fileName);
    public void DeleteFile(string fileName);

    // void SaveFile
}