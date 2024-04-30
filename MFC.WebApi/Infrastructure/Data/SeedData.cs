using System.Runtime.InteropServices.JavaScript;
using System.Text.Json;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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
        Console.WriteLine();
        
        var passport = new Passport()
        {
            Series = "4517",
            Number = "543254",
            UnitCode = "432-632",
            PlaceOfBrith = "Г. Москва",
            DateOfBrith = "04.09.2002",
            DateOfIssue = "12.03.2024",
            Citizenship = "Российская Федерация"
        };
            

        builder.CreateUser("admin",  name,  passport, "Мужской" , UsersId.Admin, RolesId.Admin);
        
        var dmitry = new Name()
        {
            First = "Дмитрий",
            Middle = "Михайлович",
            Second = "Болтачев"
        };

        
        builder.CreateUser("Dmitry",  dmitry,  passport, "Мужской",UsersId.Dmitry, RolesId.Student);
        
        var nastya = new Name()
        {
            First = "Анастасия",
            Middle = "Витальевна",
            Second = "Константинова"
        };
        
        builder.CreateUser("Nastya",  nastya,  passport, "Женский", UsersId.Shmebyulok, RolesId.Student);
        
        return builder;
    }

    private static ModelBuilder CreateRoles(this ModelBuilder builder)
    {
        builder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Id = RolesId.Admin,
            Name = "admin",
            NormalizedName = "ADMIN"
        });
        
        builder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Id = RolesId.Student,
            Name = "student",
            NormalizedName = "STUDENT"
        });
        
        return builder;
    }

    private static ModelBuilder CreateUser(this ModelBuilder builder, string userName, Name name, Passport passport, string sex, string userId, string roleId)
    {
        var hasher = new PasswordHasher<Student>();
        var email = $"{userName}@example.com";
        
        string jsonName = JsonSerializer.Serialize(name);
        string jsonPassport = JsonSerializer.Serialize(passport);
        
        var student = new Student()
        {
            Id = userId,
            UserName = userName,
            NormalizedUserName = userName.ToUpper(),
            Email = email,
            NormalizedEmail = email.ToUpper(),
            EmailConfirmed = false,
            PasswordHash = hasher.HashPassword(null, $"{userName}123"),
            SecurityStamp = string.Empty,
            Name = jsonName,
            Passport = jsonPassport,
            Group = "УВП-411",
            DirectionOfStudy = "09.03.01",
            ServiceNumber = "12345678",
            Gender = sex,
            INN = "7777065424",
            SNILS = "375232753"
        };
        
        builder.Entity<Student>().HasData(student);
        
        builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = roleId,
            UserId = userId
        });
        
        return builder;
    }

}

public static class UsersId
{
    public const string Admin = "a18be9c0-aa65-4af8-bd17-00bd9344e576";
    public const string Dmitry = "a18be9c0-aa65-4af8-bd17-00bd9344e577";
    public const string Shmebyulok = "a18be9c0-aa65-4af8-bd17-00bd9344e578";

}

public static class RolesId
{
    public const string Admin = "ad376a8f-9eab-4bb9-9fca-30b01540f446";
    public const string Student = "ad376a8f-9eab-4bb9-9fca-30b01540f447";
}