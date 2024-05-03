using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Infrastructure.Data.Configurations;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Infrastructure.Data;

public class MfcContext : IdentityDbContext<AppUser>
{
    public MfcContext()
    {
    }

    public MfcContext(DbContextOptions<MfcContext> options)
        : base(options)
    {
    }
    public virtual DbSet<Statement> Statements { get; set; }

    public virtual DbSet<StatementSchema> StatementSchemas { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.ApplyConfiguration(new StatementSchemaConfiguration());
        builder.ApplyConfiguration(new StatementConfiguration());
        
        // builder.Entity<AppUser>(entity => { entity.ToTable("AspNetUsers"); });
        // builder.Entity<StudentUser>(entity => { entity.ToTable("StudentUser"); });
        // builder.Entity<EmployeeUser>(entity => { entity.ToTable("EmployeeUser"); });
        
        builder.Seed();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        var connectionsStr = Environment.GetEnvironmentVariable("DATABASE_CONNECT") ??
                             "Server=localhost;Port=5432;Database=MFC_DB;User Id=postgres;Password=postgres";

        
        optionsBuilder.UseNpgsql(connectionsStr);
    }
}
