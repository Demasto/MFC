using Domain.Entities;
using Domain.DTO;

namespace Infrastructure.Repo;

public interface IServiceRepository
{
    public List<Service> GetAll();
    
    public Service Get(string serviceName);
    public bool Contain(string serviceName);
    public bool Switch(string serviceName);

    public void Add(ServiceDTO service);
    public void Update(UpdateServiceDTO service);
    public Service Remove(string serviceName);
    public void RemoveAll();
}