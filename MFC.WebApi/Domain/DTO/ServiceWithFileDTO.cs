using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Domain.DTO;

public class ServiceWithFileDTO : ServiceDTO
{
    [Required]
    public IFormFile File { get; set; }
}