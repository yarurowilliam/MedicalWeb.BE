using MedicalWeb.BE.Infraestructure.Data;
using MedicalWeb.BE.Transversales;
using MedicalWeb.BE.Transversales.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MedicalWeb.BE.Infraestructure.Persistence.EntityConfigurations;

public class DiasEntityConfiguration : IEntityTypeConfiguration<Dias>
{
    public void Configure(EntityTypeBuilder<Dias> builder)
    {
        builder.ToTable(
            DbConstants.Tables.Dias,
            DbConstants.Schemas.Dbo)
           .HasKey(x => x.DiaID);

        builder
            .Property(x => x.Code)
            .HasMaxLength(DbConstants.StringLength.EstateCode)
            .IsRequired();

        builder
            .HasIndex(x => x.Code)
            .IsUnique();
    }   
}