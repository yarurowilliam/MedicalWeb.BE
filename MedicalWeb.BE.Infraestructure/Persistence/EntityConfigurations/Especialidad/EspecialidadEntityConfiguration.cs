using MedicalWeb.BE.Infraestructure.Data;
using MedicalWeb.BE.Transversales.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MedicalWeb.BE.Infraestructure.Persistence.EntityConfigurations;

public class EspecialidadEntityConfiguration : IEntityTypeConfiguration<Especialidad>
{
    public void Configure(EntityTypeBuilder<Especialidad> builder)
    {
        builder.ToTable(
                DbConstants.Tables.Especialidades,
                DbConstants.Schemas.Dbo)
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Nombre)
            .HasMaxLength(DbConstants.StringLength.Names)
            .IsRequired();

        builder.Property(x => x.Descripcion)
            .HasMaxLength(DbConstants.StringLength.Description)
            .IsRequired();

        builder.Property(x => x.Estado)
            .IsRequired();

        builder
            .HasIndex(x => x.Nombre)
            .IsUnique();
    }
}