using System.ComponentModel.DataAnnotations;
using Domain.Entities;

namespace Domain.DTO;

public class UpdateServiceDTO : ServiceDTO
{
    
    [Required]
    public string NewName { get; set; } = null!;
    
}