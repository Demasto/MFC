using Domain.DTO;
using Domain.Entities;
using Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repo;

public class ServiceRepository(MfcContext context) : IServiceRepository
{
    public List<Service> GetAll()
    {
        return context.Services.ToList();
    }
    
    public Service Get(string serviceName)
    {
        var service = context.Services.FirstOrDefault(service => service.Name == serviceName);
        if (service == null) throw new Exception("service not founded");
        return service;
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