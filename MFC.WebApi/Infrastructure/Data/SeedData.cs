using Microsoft.EntityFrameworkCore;
using Infrastructure.Data.Config;

namespace Infrastructure.Data;

public static class SeedData
{
    public static void Seed(this ModelBuilder builder)
    {
        Console.WriteLine("init");
        
        builder.CreateRoles();

        builder
            .InitAdminAccount()
            .InitStudents()
            .InitEmployees();
    }
}

