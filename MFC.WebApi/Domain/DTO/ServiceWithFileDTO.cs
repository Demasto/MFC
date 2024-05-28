using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http;

namespace Domain.DTO;

public class ServiceWithFileDTO : ServiceDTO
{
    [Required]
    public IFormFile File { get; set; }
}