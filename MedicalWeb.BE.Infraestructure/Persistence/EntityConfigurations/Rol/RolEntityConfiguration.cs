using MedicalWeb.BE.Infraestructure.Data;
using MedicalWeb.BE.Infraestructure.Migrations;
using MedicalWeb.BE.Transversales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalWeb.BE.Infraestructure.Persistence.EntityConfigurations;

public class RolEntityConfiguration : IEntityTypeConfiguration<Rol>
{
    public void Configure(EntityTypeBuilder<Rol> builder)
    {
        builder.ToTable(
            DbConstants.Tables.Rol,
            DbConstants.Schemas.Dbo)
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Nombre)
            .HasMaxLength(DbConstants.StringLength.EstateCode)
            .IsRequired();

        builder
            .HasIndex(x => x.Nombre)
            .IsUnique();
    }
}
