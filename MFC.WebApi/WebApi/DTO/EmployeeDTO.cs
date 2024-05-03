using System.ComponentModel.DataAnnotations;

namespace WebApi.DTO;


public class EmployeeDTO
{
    [Required]
    public string UserName { get; set; } = "";
    
    [Required]
    public string Password { get; set; } = "";
    [Required]
    public string Post { get; set; } = "";

    [Required]
    [EmailAddress]
    public string Email { get; set; } = "";
    [Phone]
    public string PhoneNumber { get; set; } = "";
    [Required]
    public string Gender { get; set; } = "";
    [Required]
    public string INN { get; set; } = "";
    [Required]
    public string SNILS { get; set; } = "";

    public NameDTO Name { get; set; } = new NameDTO();
    public PassportDTO Passport { get; set; } = new PassportDTO();
}