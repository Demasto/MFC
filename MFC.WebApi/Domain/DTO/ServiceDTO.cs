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
    public ServiceType Type { get; set; }

    public Service ToEntity()
    {
        return new Service()
        {
            Name = Name,
            NormalizedName = Name.ToUpper(),
            Description = Description,
            Type = Type,
            OnPublic = false
        };
    }
}