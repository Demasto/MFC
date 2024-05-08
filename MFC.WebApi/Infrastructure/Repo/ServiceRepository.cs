using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repo;

public class ServiceRepository(MfcContext context) : IServiceRepository
{
    public List<Service> Get()
    {
        return context.Services.ToList();
    }
    public void Add(ServiceDTO dto)
    {
        context.Services.Add(dto.ToEntity());
        context.SaveChanges();
    }
    public void Remove(string serviceName)
    {
        var service = context.Services.FirstOrDefault(service => service.Name == serviceName);
        if (service == null) throw new Exception("service not founded");
        context.Services.Remove(service);
        context.SaveChanges();
    }

    public void RemoveAll()
    {
        context.Services.ForEachAsync(service => context.Services.Remove(service));
        context.SaveChanges();
    }
}