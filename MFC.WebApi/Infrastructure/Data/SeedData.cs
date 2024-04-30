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
            DateOfBrith = new DateOnly(2002, 02, 14),
            DateOfIssue = new DateOnly(2024, 12, 03),
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
            Name = Role.Admin,
            NormalizedName = Role.Admin.ToUpper()
        });
        
        builder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Id = RolesId.Student,
            Name = Role.Student,
            NormalizedName = Role.Student.ToUpper()
        });
        
        return builder;
    }

    private static ModelBuilder CreateUser(this ModelBuilder builder, string userName, Name name, Passport passport, string sex, string userId, string roleId)
    {
        var hasher = new PasswordHasher<AppUser>();
        var email = $"{userName}@example.com";
        
        
        var student = new AppUser()
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
        
        builder.Entity<AppUser>().HasData(student);
        
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
    public const string Admin = "a18be9c0-aa65-4af8-bd17-00bd9344e586";
    public const string Dmitry = "a18be9c0-aa65-4af8-bd17-00bd9344e587";
    public const string Shmebyulok = "a18be9c0-aa65-4af8-bd17-00bd9344e588";

}

public static class RolesId
{
    public const string Admin = "ad376a8f-9eab-4bb9-9fca-30b01540f446";
    public const string Student = "ad376a8f-9eab-4bb9-9fca-30b01540f447";
}