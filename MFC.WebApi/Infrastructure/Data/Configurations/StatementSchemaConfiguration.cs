using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class StatementSchemaConfiguration : IEntityTypeConfiguration<StatementSchema>
{
    public void Configure(EntityTypeBuilder<StatementSchema> entity)
    {
        entity.HasKey(e => e.Id).HasName("statement_schemas_pkey");

        entity.ToTable("statement_schemas");

        entity.Property(e => e.Id)
            .UseIdentityAlwaysColumn()
            .HasColumnName("id");
        entity.Property(e => e.DataId)
            .HasColumnType("character varying")
            .HasColumnName("data_id");
        entity.Property(e => e.FileId).HasColumnName("file_id");
        entity.Property(e => e.FontSize)
            .HasDefaultValue(14)
            .HasColumnName("font_size");
        entity.Property(e => e.X).HasColumnName("x");
        entity.Property(e => e.Y).HasColumnName("y");

        entity.HasOne(d => d.File).WithMany(p => p.StatementSchemas)
            .HasForeignKey(d => d.FileId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("statement_schemas_file_id_fkey");
    }
}