using MedicalWeb.BE.Infraestructure.Data;
using MedicalWeb.BE.Transversales.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MedicalWeb.BE.Transversales;

namespace MedicalWeb.BE.Infraestructure.Persitence.EntityConfigurations;

public class UsuarioEntityConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable(
        DbConstants.Tables.Usuarios,
        DbConstants.Schemas.Dbo);

        builder.HasKey(e => e.Identificacion);

        builder.Property(e => e.Identificacion)
            .HasColumnName("Identificacion")
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(e => e.NombreUsuario)
            .HasColumnName("NombreUsuario")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.Password)
            .HasColumnName("Password")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.Estado)
            .HasColumnName("Estado")
            .HasMaxLength(1)
            .IsRequired();
    }
}