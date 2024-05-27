namespace Domain.Entities;

public static class Role
{
    public const string Admin = "admin";
    public const string Student = "student";
    public const string Employee = "employee";
    
    public static readonly string[] Array = new []{Admin, Student, Employee};
}
