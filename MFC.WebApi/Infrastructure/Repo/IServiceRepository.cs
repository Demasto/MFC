using Domain.Entities;
using Infrastructure.Models.DTO;

namespace Infrastructure.Repo;

public interface IServiceRepository
{
    public List<Service> Get();

    public void Add(ServiceDTO service);
    public void Remove(string serviceName);
}