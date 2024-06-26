﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using Domain.Entities.Users;
using Task = Domain.Entities.Task;

namespace Infrastructure.Data;

public class MfcContext : IdentityDbContext<AppUser>
{
    public MfcContext() { }

    public MfcContext(DbContextOptions<MfcContext> options) : base(options) { }
    
    public virtual DbSet<Service> Services { get; set; }
    public virtual DbSet<Task> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Seed();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        var connectionsStr = Environment.GetEnvironmentVariable("DATABASE_CONNECT") ??
                             "Server=localhost;Port=5432;Database=MFC;User Id=postgres;Password=postgres";

        
        optionsBuilder.UseNpgsql(connectionsStr);
    }
}
