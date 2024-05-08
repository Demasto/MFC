using System.ComponentModel.DataAnnotations;
using Domain.Entities;

namespace Domain.DTO;

public class ServiceDTO
{
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public string Description { get; set; } = null!;
    [Required]
    public string FileName { get; set; } = null!;
    [Required]
    public ServiceType Type { get; set; } = ServiceType.Certificate;

    public Service ToEntity()
    {
        return new Service()
        {
            Name = Name,
            Description = Description,
            Type = Type,
            FileName = FileName
        };
    }
}