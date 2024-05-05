using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using Infrastructure.Identity.Users;

namespace WebApi.DTO;

public class AppUserDTO
{
    [Required]
    public string UserName { get; set; } = "";
    
    [Required]
    public string Password { get; set; } = "";

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
    
    
    public AppUser ToIdentityUser()
    {
        return new AppUser() {
            UserName = UserName,
            Email = Email,
            PhoneNumber = PhoneNumber,
            Gender = Gender,
            INN = INN,
            SNILS = SNILS,
            Name = JsonSerializer.Serialize(Name),
            Passport = JsonSerializer.Serialize(Passport)
        };
    }
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
    public string PlaceOfBrith { get; set; } = "";
    public DateOnly DateOfBrith { get; set; }
    public DateOnly DateOfIssue { get; set; }
    public string Citizenship { get; set; } = "";

}