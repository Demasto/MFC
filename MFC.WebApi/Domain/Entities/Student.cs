using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

using Microsoft.AspNetCore.Identity;

public class Student : IdentityUser
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

[Keyless]
public class Passport
{
    
    public string Series { get; set; } = "";
    public string Number { get; set; } = "";
    public string UnitCode { get; set; } = "";
    public string PlaceOfBrith { get; set; } = "";
    public string DateOfBrith { get; set; } = "";
    public string DateOfIssue { get; set; } = "";
    public string Citizenship { get; set; } = "";

}

[Keyless]
public class Name()
{
    public string First { get; set; } = "";
    public string Second { get; set; } = "";
    public string Middle { get; set; } = "";
}