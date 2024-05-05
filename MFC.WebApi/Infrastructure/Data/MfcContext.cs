using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using Infrastructure.Identity.Users;

namespace Infrastructure.Data;

public class MfcContext : IdentityDbContext<AppUser>
{
    public MfcContext() { }

    public MfcContext(DbContextOptions<MfcContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
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
