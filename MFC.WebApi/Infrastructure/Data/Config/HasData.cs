using System.Text.Json;
using Domain.Entities.Users;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public static class HasData
{
    public static ModelBuilder HasUser(this ModelBuilder builder, string userName, Name name, string sex, string userId, string roleId)
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

    public static ModelBuilder HasEmployee(this ModelBuilder builder)
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