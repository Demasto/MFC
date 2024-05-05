using System.Text.Json;
using Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;

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

    
    public User ToEntity()
    {
        return new User
        {
            UserName = UserName!,
            Name = JsonSerializer.Deserialize<Name>(Name)!,
            Passport = JsonSerializer.Deserialize<Passport>(Passport)!,
            Email = Email!, 
            PhoneNumber = PhoneNumber!,
            Gender = Gender, 
            INN = INN, 
            SNILS = SNILS,
        };
    }
    
}