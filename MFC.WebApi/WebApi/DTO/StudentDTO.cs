using System.ComponentModel.DataAnnotations;

namespace WebApi.DTO;


public class StudentDTO
{
    [Required]
    public string UserName { get; set; } = "";
    
    [Required]
    public string Password { get; set; } = "";
    [Required]
    public string Group { get; set; } = "";
    [Required]
    public string DirectionOfStudy { get; set; } = "";
    [Required]
    public string ServiceNumber { get; set; } = "";
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
    public NameDTO Name { get; set; }
    public PassportDTO Passport { get; set; }
}

public class NameDTO()
{
    [Required]
    public string First { get; set; } = "";
    [Required]
    public string Second { get; set; } = "";
    [Required]
    public string Middle { get; set; } = "";
}

public class PassportDTO
{
    public string Series { get; set; } = "";
    public string Number { get; set; } = "";
    public string UnitCode { get; set; } = "";
    public string PlaceOfBrith { get; set; }
    public DateOnly DateOfBrith { get; set; }
    public DateOnly DateOfIssue { get; set; }
    public string Citizenship { get; set; } = "";

}