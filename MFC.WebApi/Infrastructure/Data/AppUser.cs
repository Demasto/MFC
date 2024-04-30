using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Data;

public class AppUser : IdentityUser
{
    public string Name { get; set; } = "";
    public string Passport { get; set; } = "";
    public string Group { get; set; } = null!;
    public string DirectionOfStudy { get; set; } = null!;
    public string ServiceNumber { get; set; } = null!;
    
    public string Gender { get; set; } = "";
    
    public string INN { get; set; } = "";
    public string SNILS { get; set; } = "";
}

public static class Role
{
    public const string Admin = "admin";
    public const string Student = "student";
}