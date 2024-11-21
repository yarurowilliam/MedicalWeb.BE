using MedicalWeb.BE.Infraestructure.Data;
using MedicalWeb.BE.Transversales.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MedicalWeb.BE.Infraestructure.Persistence.EntityConfigurations;

public class YearsEntityConfiguration : IEntityTypeConfiguration<Years>
{
    public void Configure(EntityTypeBuilder<Years> builder)
    {
        builder.ToTable
            (
                DbConstants.Tables.Years,
                DbConstants.Schemas.Dbo
            )
            .HasKey(x => x.YearsID);

        builder
            .Property(x => x.Code)
            .HasMaxLength(DbConstants.StringLength.EstateCode)
            .IsRequired();
        builder
            .HasIndex(x => x.Code)
            .IsUnique();
    }
}