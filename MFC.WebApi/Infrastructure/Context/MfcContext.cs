﻿using Microsoft.EntityFrameworkCore;
using Domain.Models;
using Infrastructure.Context.EntityConfiguration;

namespace Infrastructure.Context;

public class MfcContext : DbContext
{
    public MfcContext(DbContextOptions<MfcContext> options) : base(options) { }

    public virtual DbSet<FileSchema> FileSchemas { get; set; }
    public virtual DbSet<Statement> Statements { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=MFC;User Id=postgres;Password=postgres");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new FileSchemaConfiguration());
        modelBuilder.ApplyConfiguration(new StatementConfiguration());
    }
}
