using MedicalWeb.BE.Infraestructure.Data;
using MedicalWeb.BE.Transversales.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalWeb.BE.Infraestructure.Persitence.EntityConfigurations
{
    public class UsuarioRolesEntityConfiguration : UsuarioRoles
    {
        //public void Configure(EntityTypeBuilder<UsuarioRoles> builder)
        //{
        //    builder.ToTable(
        //        DbConstants.Tables.UsuarioRoles, // Nombre de la tabla
        //        DbConstants.Schemas.Dbo          // Esquema
        //    );

        //    // Configuración de la clave primaria
        //    builder.HasKey(e => e.Id);

        //    // Configuración de las propiedades
        //    builder.Property(e => e.UsuarioId)
        //        .HasColumnName("UsuarioId")
        //        .HasMaxLength(20)
        //        .IsRequired();

        //    builder.Property(e => e.RolId)
        //        .HasColumnName("RolId")
        //        .IsRequired();

        //    // Configuración de las relaciones sin propiedades de navegación
        //    builder.HasIndex(e => e.UsuarioId); // Índice para mejorar consultas por UsuarioId
        //    builder.HasIndex(e => e.RolId); // Índice para mejorar consultas por RolId
        //}
    }
}