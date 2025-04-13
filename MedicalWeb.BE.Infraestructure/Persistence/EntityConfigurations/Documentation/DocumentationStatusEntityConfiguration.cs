using MedicalWeb.BE.Infraestructure.Data;
using MedicalWeb.BE.Transversales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalWeb.BE.Infraestructure.Persistence.EntityConfigurations.Documentation;

public class DocumentationStatusEntityConfiguration : IEntityTypeConfiguration<DocumentationStatus>
{
    public void Configure(EntityTypeBuilder<DocumentationStatus> builder)
    {
        builder.ToTable(
                DbConstants.Tables.DocumentationStatuses,
                DbConstants.Schemas.Dbo)
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Code)
            .HasMaxLength(DbConstants.StringLength.Code)
            .IsRequired();

        builder
            .HasIndex(x => x.Code)
            .IsUnique();
    }
}
