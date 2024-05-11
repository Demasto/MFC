using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Config;

public static class DefaultRoles
{
    public static void CreateRoles(this ModelBuilder builder)
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
    }
}