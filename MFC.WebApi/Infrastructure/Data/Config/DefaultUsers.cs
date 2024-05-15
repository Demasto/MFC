using Microsoft.EntityFrameworkCore;

using Domain.DTO.Users;

namespace Infrastructure.Data;

public static class DefaultUsers
{
    public static ModelBuilder InitAdminAccount(this ModelBuilder builder)
    {
        builder.HasAdmin();
        return builder;
    }

    public static ModelBuilder InitStudents(this ModelBuilder builder)
    {
        var dmitry = new NameDTO()
        {
            First = "Дмитрий",
            Middle = "Михайлович",
            Second = "Болтачев"
        };

        
        builder.HasStudent("Dmitry",  dmitry, UsersId.Dmitry, RolesId.Student, "12345678");
        
        var nastya = new NameDTO()
        {
            First = "Анастасия",
            Middle = "Витальевна",
            Second = "Константинова"
        };
        
        builder.HasStudent("Nastya",  nastya, UsersId.Shmebyulok, RolesId.Student, "87654321");

        return builder;
    }

    public static ModelBuilder InitEmployees(this ModelBuilder builder)
    {
        builder.HasEmployee();
        return builder;
    }
}

public static class UsersId
{
    public const string Admin = "d28be9c0-aa65-4af8-bd17-10bd9344e586";
    public const string Dmitry = "738be9c0-aa65-4af8-bd17-10bd9344e587";
    public const string Shmebyulok = "738be9c0-aa65-4af8-1d17-10bd9344e588";
    public const string Employee = "d28be9c0-aa65-4af8-bd17-10bd9344e588";

}

public static class RolesId
{
    public const string Admin = "bd376a8f-9eab-4bb9-9fca-40b01540f446";
    public const string Student = "bd376a8f-9eab-4bb9-9fca-40b01540f447";
    public const string Employee = "bd376a8f-9eab-4bb9-9fca-40b01540f448";
}