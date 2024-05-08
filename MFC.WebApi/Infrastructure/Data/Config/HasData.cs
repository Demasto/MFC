using System.Text.Json;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using Domain.DTO.Users;
using Domain.Entities.Users;

namespace Infrastructure.Data;

public static class HasData
{
    public static ModelBuilder HasAdmin(this ModelBuilder builder)
    {
        var hasher = new PasswordHasher<AppUser>();

        const string userName = "admin";
        const string email = "admin@example.com";
        
        var name = new NameDTO()
        {
            First = "Admin",
            Middle = "Adminovich",
            Second = "Adminov"
        };
        
        var admin = new AppUser()
        {
            Id = UsersId.Admin,
            UserName = userName,
            NormalizedUserName = userName.ToUpper(),
            Email = email,
            NormalizedEmail = email.ToUpper(),
            EmailConfirmed = false,
            PasswordHash = hasher.HashPassword(null, $"{userName}123"),
            SecurityStamp = string.Empty,
            Name = JsonSerializer.Serialize(name),
            Passport = JsonSerializer.Serialize(PassportDTO.Default()),
            Gender = "admin",
            INN = "7777065424",
            SNILS = "375232753"
        };
        
        builder.Entity<AppUser>().HasData(admin);
        
        builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = RolesId.Admin,
            UserId = UsersId.Admin
        });
        
        return builder;
    }
    public static ModelBuilder HasStudent(this ModelBuilder builder, string userName, NameDTO name, string sex, string userId, string roleId)
    {
        var hasher = new PasswordHasher<StudentUser>();
        var email = $"{userName}@example.com";

        
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
            Passport = JsonSerializer.Serialize(PassportDTO.Default()),
            Group = "УВП-411",
            DirectionOfStudy = "09.03.01",
            FormOfStudy = "очная",
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

    public static ModelBuilder HasEmployee(this ModelBuilder builder)
    {
        const string userName = "employee";
        const string email = $"{userName}@example.com";
        
        var hasher = new PasswordHasher<EmployeeUser>();
        
        var worker = new NameDTO()
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
            Passport = JsonSerializer.Serialize(PassportDTO.Default()),
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