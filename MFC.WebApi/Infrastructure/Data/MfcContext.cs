using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Infrastructure.Data.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Infrastructure.Data;

public class MfcContext : IdentityDbContext<Student>
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
        
        builder.Seed();
    }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     base.OnConfiguring(optionsBuilder);
    //     optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("DATABASE_CONNECT"));
    // }
}
