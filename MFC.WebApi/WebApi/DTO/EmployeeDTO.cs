using System.ComponentModel.DataAnnotations;

namespace WebApi.DTO;


public class EmployeeDTO : AppUserDTO
{
    [Required]
    public string Post { get; set; } = "";
  
}