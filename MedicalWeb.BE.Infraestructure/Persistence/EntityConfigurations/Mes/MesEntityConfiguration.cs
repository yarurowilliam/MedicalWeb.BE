using MedicalWeb.BE.Infraestructure.Data;
using MedicalWeb.BE.Transversales.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MedicalWeb.BE.Infraestructure.Persistence.EntityConfigurations;

public class MesEntityConfiguration : IEntityTypeConfiguration<Mes>
{
    public void Configure(EntityTypeBuilder<Mes> builder)
    {
        builder.ToTable
            (
                DbConstants.Tables.Mes,
                DbConstants.Schemas.Dbo
            )
            .HasKey(x => x.MesID);

        builder
            .Property(x => x.Code)
            .HasMaxLength(DbConstants.StringLength.EstateCode)
            .IsRequired();

        builder
            .HasIndex(x => x.Code)
            .IsUnique();
    }
}