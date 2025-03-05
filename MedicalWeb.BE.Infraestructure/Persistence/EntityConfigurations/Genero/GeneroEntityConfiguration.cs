using MedicalWeb.BE.Infraestructure.Data;
using MedicalWeb.BE.Transversales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalWeb.BE.Infraestructure.Persistence.EntityConfigurations;

public class GeneroEntityConfiguration :IEntityTypeConfiguration<Generos>
{
    public void Configure(EntityTypeBuilder<Generos> builder)
    {
        builder.ToTable(
            DbConstants.Tables.Generos,
            DbConstants.Schemas.Dbo)
           .HasKey(x => x.Id);

        builder
            .Property(x => x.Code)
            .HasMaxLength(DbConstants.StringLength.EstateCode)
            .IsRequired();

        builder
            .HasIndex(x => x.Code)
            .IsUnique();
    }
}