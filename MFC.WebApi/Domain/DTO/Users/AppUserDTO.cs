using System.ComponentModel.DataAnnotations;
using System.Text.Json;

using Domain.Entities.Users;

namespace Domain.DTO.Users;

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
    
    protected AppUser ToIdentityUser()
    {
        return new AppUser() {
            UserName = UserName,
            NormalizedEmail = UserName.ToUpper(),
            Email = Email,
            NormalizedUserName = Email.ToUpper(),
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

    public static PassportDTO Default()
    {
        return new PassportDTO()
        {
            Series = "4517",
            Number = "543254",
            UnitCode = "432-632",
            PlaceOfBrith = "Г. Москва",
            DateOfBrith = new DateOnly(2002, 02, 14),
            DateOfIssue = new DateOnly(2024, 12, 03),
            Citizenship = "Российская Федерация"
        };
    }

}