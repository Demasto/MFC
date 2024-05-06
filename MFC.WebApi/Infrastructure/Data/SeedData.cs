using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using Infrastructure.Identity;

namespace Infrastructure.Data;

public static class SeedData
{
    public static ModelBuilder Seed(this ModelBuilder builder)
    {
        Console.WriteLine("init");

        builder.CreateRoles();

        builder.InitAdminAccount();
        builder.InitStudents();
        builder.InitEmployees();
        
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
    

}

