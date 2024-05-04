using System.ComponentModel.DataAnnotations;

namespace WebApi.DTO;


public class StudentDTO : AppUserDTO
{
    [Required]
    public string Group { get; set; } = "";
    [Required]
    public string DirectionOfStudy { get; set; } = "";
    [Required]
    public string ServiceNumber { get; set; } = "";
}

