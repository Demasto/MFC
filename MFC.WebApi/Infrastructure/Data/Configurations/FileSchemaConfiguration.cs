using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class FileSchemaConfiguration : IEntityTypeConfiguration<FileSchema>
{
    public void Configure(EntityTypeBuilder<FileSchema> entity)
    {
        entity.HasKey(e => e.FileSchemaId).HasName("file_schemas_pkey");

        entity.ToTable("file_schemas");

        entity.Property(e => e.FileSchemaId)
            .UseIdentityAlwaysColumn()
            .HasColumnName("file_schema_id");
        
        entity.Property(e => e.DataId)
            .HasColumnType("character varying")
            .HasColumnName("data_id");
        entity.Property(e => e.FileId).HasColumnName("file_id");
        
        entity.Property(e => e.FontSize)
            .HasDefaultValue(14)
            .HasColumnName("font_size");
        
        entity.Property(e => e.X).HasColumnName("x");
        entity.Property(e => e.Y).HasColumnName("y");

        entity.HasOne(d => d.File).WithMany(p => p.FileSchemas)
            .HasForeignKey(d => d.FileId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("file_schemas_file_id_fkey");
    }
}