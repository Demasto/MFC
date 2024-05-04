using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class StatementConfiguration : IEntityTypeConfiguration<Statement>
{
    public void Configure(EntityTypeBuilder<Statement> entity)
    {
        entity.HasKey(e => e.Id).HasName("statements_pkey");

        entity.ToTable("statements");

        entity.Property(e => e.Id)
            .UseIdentityAlwaysColumn()
            .HasColumnName("id");
        entity.Property(e => e.Name)
            .HasColumnType("character varying")
            .HasColumnName("name");
        entity.Property(e => e.Path)
            .HasColumnType("character varying")
            .HasColumnName("path");
    }
}