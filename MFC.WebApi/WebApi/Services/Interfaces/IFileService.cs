using Domain.Entities;
using Task = System.Threading.Tasks.Task;

namespace WebApi.Services.Interfaces;

public interface IFileService
{
    public IEnumerable<string> GetAllFromType(ServiceType type);

    public Task Create(string fileName, Stream stream, ServiceType type);
    public FileStream Read(string fileName, ServiceType type);
    public Task Update(string fileName, Stream stream, ServiceType type);
    public string FromServiceName(string serviceName, ServiceType type);
    public string FromService(Service service);
    public void Delete(string fileName, ServiceType type);

    // void SaveFile
}