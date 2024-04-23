using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Infrastructure.Data.Configurations;

namespace Infrastructure.Data;

public class MfcContext : DbContext
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new StatementSchemaConfiguration());
        modelBuilder.ApplyConfiguration(new StatementConfiguration());
    }
}
