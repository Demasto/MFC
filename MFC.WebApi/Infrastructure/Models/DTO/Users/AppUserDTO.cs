using System.ComponentModel.DataAnnotations;
using System.Text.Json;

using Infrastructure.Identity;

namespace Infrastructure.DTO;

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
    
    public AppUserDTO() {}
    protected AppUserDTO(AppUserDTO user)
    {
        UserName = user.UserName;
        Email = user.Email;
        PhoneNumber = user.PhoneNumber;
        Gender = user.Gender;
        INN = user.INN;
        SNILS = user.SNILS;
        Name = user.Name;
        Passport = user.Passport;
    }
    
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
    
    public Dictionary<string, object?> ToDictionary()
    {
        var info = new Dictionary<string, object?>();
        var obj = GetType();
        var props = obj.GetProperties();
        foreach (var property in props)
        {
            if(property.Name == "Password") continue;
            info[property.Name.ToLower()] = property.GetValue(this);
        }

        return info;
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