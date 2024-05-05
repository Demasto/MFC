using System.Text.Json;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using Domain.Entities.Users;
using Infrastructure.Identity;
using Infrastructure.Identity.Users;

namespace Infrastructure.Data;

public static class SeedData
{
    public static ModelBuilder Seed(this ModelBuilder builder)
    {
        Console.WriteLine("init");

        builder.CreateRoles();
        
        var name = new Name()
        {
            First = "Admin",
            Middle = "Adminovich",
            Second = "Adminov"
        };

        builder.HasStudent("admin",  name, "Мужской" , UsersId.Admin, RolesId.Admin);
        
        var dmitry = new Name()
        {
            First = "Дмитрий",
            Middle = "Михайлович",
            Second = "Болтачев"
        };

        
        builder.HasStudent("Dmitry",  dmitry, "Мужской",UsersId.Dmitry, RolesId.Student);
        
        var nastya = new Name()
        {
            First = "Анастасия",
            Middle = "Витальевна",
            Second = "Константинова"
        };
        
        builder.HasStudent("Nastya",  nastya, "Женский", UsersId.Shmebyulok, RolesId.Student);
        
        
        builder.HasEmployee();
        
        return builder;
    }

    private static ModelBuilder CreateRoles(this ModelBuilder builder)
    {
        builder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Id = RolesId.Admin,
            Name = Role.Admin,
            NormalizedName = Role.Admin.ToUpper()
        });
        
        builder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Id = RolesId.Student,
            Name = Role.Student,
            NormalizedName = Role.Student.ToUpper()
        });
        
        builder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Id = RolesId.Employee,
            Name = Role.Employee,
            NormalizedName = Role.Employee.ToUpper()
        });
        
        return builder;
    }

    private static ModelBuilder HasStudent(this ModelBuilder builder, string userName, Name name, string sex, string userId, string roleId)
    {
        var hasher = new PasswordHasher<StudentUser>();
        var email = $"{userName}@example.com";
        var passport = new Passport()
        {
            Series = "4517",
            Number = "543254",
            UnitCode = "432-632",
            PlaceOfBrith = "Г. Москва",
            DateOfBrith = new DateOnly(2002, 02, 14),
            DateOfIssue = new DateOnly(2024, 12, 03),
            Citizenship = "Российская Федерация"
        };
        
        var student = new StudentUser()
        {
            Id = userId,
            UserName = userName,
            NormalizedUserName = userName.ToUpper(),
            Email = email,
            NormalizedEmail = email.ToUpper(),
            EmailConfirmed = false,
            PasswordHash = hasher.HashPassword(null, $"{userName}123"),
            SecurityStamp = string.Empty,
            Name = JsonSerializer.Serialize(name),
            Passport = JsonSerializer.Serialize(passport),
            Group = "УВП-411",
            DirectionOfStudy = "09.03.01",
            ServiceNumber = "12345678",
            Gender = sex,
            INN = "7777065424",
            SNILS = "375232753"
        };
        
        builder.Entity<StudentUser>().HasData(student);
        
        builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = roleId,
            UserId = userId
        });
        
        return builder;
    }
    
    private static ModelBuilder HasEmployee(this ModelBuilder builder)
    {
        const string userName = "employee";
        const string email = $"{userName}@example.com";
        
        var hasher = new PasswordHasher<EmployeeUser>();

        var passport = new Passport()
        {
            Series = "4517",
            Number = "543254",
            UnitCode = "432-632",
            PlaceOfBrith = "Г. Москва",
            DateOfBrith = new DateOnly(2002, 02, 14),
            DateOfIssue = new DateOnly(2024, 12, 03),
            Citizenship = "Российская Федерация"
        };
        
        var worker = new Name()
        {
            First = "Работник",
            Middle = "Институтович",
            Second = "МИИТОВ"
        };
        
        var employee = new EmployeeUser()
        {
            Id = UsersId.Employee,
            UserName = userName,
            NormalizedUserName = userName.ToUpper(),
            Email = email,
            NormalizedEmail = email.ToUpper(),
            EmailConfirmed = false,
            PasswordHash = hasher.HashPassword(null, $"{userName}123"),
            SecurityStamp = string.Empty,
            Name = JsonSerializer.Serialize(worker),
            Passport = JsonSerializer.Serialize(passport),
            Post = "Доцент",
            Gender = "Мужской",
            INN = "7777065424",
            SNILS = "375232753"
        };
        
        builder.Entity<EmployeeUser>().HasData(employee);
        
        builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = RolesId.Employee,
            UserId = UsersId.Employee
        });
        
        return builder;
    }

}

public static class UsersId
{
    public const string Admin = "b18be9c0-aa65-4af8-bd17-10bd9344e586";
    public const string Dmitry = "b18be9c0-aa65-4af8-bd17-10bd9344e587";
    public const string Shmebyulok = "b18be9c0-aa65-4af8-1d17-10bd9344e588";
    public const string Employee = "b18be9c0-aa65-4af8-bd17-10bd9344e588";

}

public static class RolesId
{
    public const string Admin = "bd376a8f-9eab-4bb9-9fca-40b01540f446";
    public const string Student = "bd376a8f-9eab-4bb9-9fca-40b01540f447";
    public const string Employee = "bd376a8f-9eab-4bb9-9fca-40b01540f448";
}