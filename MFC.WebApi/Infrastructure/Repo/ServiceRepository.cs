using Domain.DTO;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repo;

public class ServiceRepository(MfcContext context) : IServiceRepository
{
    public List<Service> GetAll()
    {
        return context.Services.ToList();
    }
    
    public Service Get(string serviceName)
    {
        var service = context.Services.FirstOrDefault(service => service.NormalizedName == serviceName.ToUpper());
        if (service == null) throw new Exception("Такой услуги не существует!");
        return service;
    }

    public bool Contain(string serviceName)
    {
        var service = context.Services.FirstOrDefault(service => service.NormalizedName == serviceName.ToUpper());
        return service != null;
    }

    public bool Switch(string serviceName)
    {
        var service = Get(serviceName);
        service.OnPublic = !service.OnPublic;
        context.SaveChanges();
        return service.OnPublic;
    }
    public void Add(ServiceDTO dto)
    {
        if (Contain(dto.Name))
            throw new Exception("Такая услуга уже существует!");
        
        context.Services.Add(dto.ToEntity());
        context.SaveChanges();
    }
    
    public void Update(UpdateServiceDTO dto)
    {
        var service = Get(dto.Name);

        service.Name = dto.NewName;
        service.NormalizedName = dto.NewName.ToUpper();
        service.Description = dto.Description;
        service.Type = dto.Type;
        
        context.Services.Update(service);
        context.SaveChanges();
    }
    
    public Service Remove(string serviceName)
    {
        var service = Get(serviceName);
        context.Services.Remove(service);
        context.SaveChanges();
        return service;
    }

    public void RemoveAll()
    {
        context.Services.RemoveRange(context.Services);
        context.SaveChanges();
    }
}