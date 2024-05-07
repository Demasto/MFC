using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Models.DTO;

namespace Infrastructure.Repo;

public class ServiceRepository(MfcContext context) : IServiceRepository
{
    public List<Service> Get()
    {
        return context.Services.ToList();
    }
    public void Add(ServiceDTO dto)
    {
        var service = new Service()
        {
            Name = dto.Name,
            Description = dto.Description,
            Type = dto.Type,
            FileName = dto.FileName
        };
        context.Services.Add(service);
        context.SaveChanges();
    }
    public void Remove(string serviceName)
    {
        var service = context.Services.FirstOrDefault(service => service.Name == serviceName);
        if (service == null) throw new Exception("service not founded");
        context.Services.Remove(service);
        context.SaveChanges();
    }
}