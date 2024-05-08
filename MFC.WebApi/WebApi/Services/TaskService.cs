using Infrastructure.Data;
using Infrastructure.Repo;

namespace WebApi.Services;

public class TaskService(MfcContext context, IServiceRepository serviceRepository)
{
    public void Add(string serviceName)
    {
        
    }
}