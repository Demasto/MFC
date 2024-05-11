using System.Text.Json;
using Microsoft.AspNetCore.Identity;

using Domain.DTO.Users;

namespace Domain.Entities.Users;

public class AppUser : IdentityUser
{
    public string Name { get; set; } = "";
    public string Passport { get; set; } = "";
        
    public string Gender { get; set; } = "";
    
    public string INN { get; set; } = "";
    public string SNILS { get; set; } = "";
    
    // public List<Task> Tasks { get; set; } = new();
    
    public AppUser() {}
    

    protected AppUser(AppUser appUser)
    {
        UserName = appUser.UserName;
        NormalizedUserName = appUser.NormalizedUserName;
        Email = appUser.Email;
        NormalizedEmail = appUser.NormalizedEmail;
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
    
    public static AppUser Default(string userName)
    {
        var email = $"{userName}@example.com";
        
        return new AppUser()
        {
            UserName = userName,
            NormalizedUserName = userName.ToUpper(),
            Email = email,
            NormalizedEmail = email.ToUpper(),
            Passport = JsonSerializer.Serialize(PassportDTO.Default()),
            Gender = "Мужской",
            INN = "7777065424",
            SNILS = "375232753",
            EmailConfirmed = false,
            SecurityStamp = string.Empty,
        };
    }

}