using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class StatementConfiguration : IEntityTypeConfiguration<Statement>
{
    public void Configure(EntityTypeBuilder<Statement> entity)
    {
        entity.HasKey(e => e.FileId).HasName("statements_pkey");

        entity.ToTable("statements");

        entity.Property(e => e.FileId)
            .UseIdentityAlwaysColumn()
            .HasColumnName("file_id");
        
        entity.Property(e => e.FileName)
            .HasColumnType("character varying")
            .HasColumnName("file_name");
        
        entity.Property(e => e.FilePath)
            .HasColumnType("character varying")
            .HasColumnName("file_path");
    }
}