using MedicalWeb.BE.Infraestructure.Data;
using MedicalWeb.BE.Transversales.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalWeb.BE.Infraestructure.Persitence.EntityConfigurations;

public class MedicoEntityConfiguration : IEntityTypeConfiguration<Medico>
{
    public void Configure(EntityTypeBuilder<Medico> builder)
    {
        builder.ToTable(
        DbConstants.Tables.Medicos,
        DbConstants.Schemas.Dbo);

        builder.HasKey(e => e.NumeroDocumento);

        builder.Property(e => e.NumeroDocumento)
            .HasColumnName("NumeroDocumento")
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(e => e.TipoDocumento)
            .HasColumnName("TipoDocumento")
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(e => e.PrimerNombre)
            .HasColumnName("PrimerNombre")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.SegundoNombre)
            .HasColumnName("SegundoNombre")
            .HasMaxLength(50);

        builder.Property(e => e.PrimerApellido)
            .HasColumnName("PrimerApellido")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.SegundoApellido)
            .HasColumnName("SegundoApellido")
            .HasMaxLength(50);

        builder.Property(e => e.CorreoElectronico)
            .HasColumnName("CorreoElectronico")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.Telefono)
            .HasColumnName("Telefono")
            .HasMaxLength(20);

        builder.Property(e => e.Celular)
            .HasColumnName("Celular")
            .HasMaxLength(20)
            .IsRequired();


        builder.Property(e => e.Direccion)
            .HasColumnName("Direccion")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.Ciudad)
            .HasColumnName("Ciudad")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.Departamento)
            .HasColumnName("Departamento")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.Pais)
            .HasColumnName("Pais")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.CodigoPostal)
            .HasColumnName("CodigoPostal")
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(e => e.Genero)
            .HasColumnName("Genero")
            .HasMaxLength(1);

        builder.Property(e => e.EstadoCivil)
            .HasColumnName("EstadoCivil")
            .IsRequired();

        builder.Property(e => e.FechaNacimiento)
            .HasColumnName("FechaNacimiento")
            .HasMaxLength(10);

        builder.Property(e => e.LugarNacimiento)
            .HasColumnName("LugarNacimiento")
            .HasMaxLength(50);

        builder.Property(e => e.Nacionalidad)
            .HasColumnName("Nacionalidad")
            .HasMaxLength(50);

        builder.Property(e => e.MatriculaProfesional)
            .HasColumnName("MatriculaProfesional")
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(e => e.Universidad)
            .HasColumnName("Universidad")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.AnioGraduacion)
            .HasColumnName("AnioGraduacion")
            .HasMaxLength(4)
            .IsRequired();

        builder.Property(e => e.FechaIngreso)
            .HasColumnName("FechaIngreso")
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(e => e.FechaSalida)
            .HasColumnName("FechaSalida")
            .HasMaxLength(10);

        builder.Property(e => e.Estado)
            .HasColumnName("Estado")
            .HasMaxLength(1)
            .IsRequired();
    }
}
