using Domain.Entities;
using Domain.DTO;

namespace Infrastructure.Repo;

public interface IServiceRepository
{
    public List<Service> GetAll();
    
    public Service Get(string serviceName);

    public void Add(ServiceDTO service);
    public void Remove(string serviceName);
    public void RemoveAll();
}