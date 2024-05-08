using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using Domain.Entities;
using Task = System.Threading.Tasks.Task;

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

        // builder.Entity<Task>().HasKey(user => user.Id);
        // builder.Entity<Task>().HasData(new Domain.Entities.Task()
        // {
        //     Id = 0,
        //     UserId = "test",
        //     ServiceName = "test",
        //     State = ProcessState.Created
        // });
        
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

