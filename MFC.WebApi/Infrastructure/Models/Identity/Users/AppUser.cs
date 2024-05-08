using System.Text.Json;
using Microsoft.AspNetCore.Identity;
using Infrastructure.DTO;

namespace Infrastructure.Identity;

public class AppUser : IdentityUser
{
    public string Name { get; set; } = "";
    public string Passport { get; set; } = "";
        
    public string Gender { get; set; } = "";
    
    public string INN { get; set; } = "";
    public string SNILS { get; set; } = "";
    
    public AppUser() {}

    protected AppUser(AppUser appUser)
    {
        UserName = appUser.UserName;
        Email = appUser.Email;
        PhoneNumber = appUser.PhoneNumber;
        Gender = appUser.Gender;
        INN = appUser.INN;
        SNILS = appUser.SNILS;
        Name = appUser.Name;
        Passport = appUser.Passport;
    }

    
    public virtual AppUserDTO ToDTO()
    {
        return new AppUserDTO
        {
            UserName = UserName!,
            Name = JsonSerializer.Deserialize<NameDTO>(Name)!,
            Passport = JsonSerializer.Deserialize<PassportDTO>(Passport)!,
            Email = Email!, 
            PhoneNumber = PhoneNumber!,
            Gender = Gender, 
            INN = INN, 
            SNILS = SNILS,
        };
    }

    public virtual string UserRole { get; } =  Role.Admin;

}

public static class Valid
{
    public static string StringProperty(string? prop)
    {
        return prop ?? string.Empty;
    }
}