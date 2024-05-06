using Domain.Entities;

namespace WebApi.Services.Interfaces;

public interface IFileService
{
    public IEnumerable<string> GetFilesList(ServiceType type);
    public Task CreateFile(string fileName, Stream stream, ServiceType type);
    public Task UpdateFile(string fileName, Stream stream, ServiceType type);
    public FileStream ReadFileStream(string fileName, ServiceType type);
    public void DeleteFile(string fileName, ServiceType type);

    // void SaveFile
}