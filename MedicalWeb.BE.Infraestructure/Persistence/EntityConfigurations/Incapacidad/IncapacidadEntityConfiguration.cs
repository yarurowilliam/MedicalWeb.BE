using MedicalWeb.BE.Infraestructure.Data;
using MedicalWeb.BE.Transversales.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalWeb.BE.Infraestructure.Persistence.EntityConfigurations;

public class IncapacidadEntityConfiguration : IEntityTypeConfiguration<Incapacidad>
{
    public void Configure(EntityTypeBuilder<Incapacidad> builder)
    {
        builder.ToTable(DbConstants.Tables.Incapacidad, DbConstants.Schemas.Dbo);

        builder.HasKey(e => e.ID);

        builder.Property(e => e.ID)
            .HasColumnName("ID")
            .IsRequired();

        builder.Property(e => e.NumeroDocumentoPaciente)
            .HasColumnName("NumeroDocumentoPaciente")
            .HasMaxLength(20)
            .IsRequired();

        builder.HasOne(e => e.Paciente)
            .WithMany()
            .HasForeignKey(e => e.NumeroDocumentoPaciente)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(e => e.NumeroDocumentoMedico)
            .HasColumnName("NumeroDocumentoMedico")
            .HasMaxLength(20)
            .IsRequired();

        builder.HasOne(e => e.Medico)
            .WithMany()
            .HasForeignKey(e => e.NumeroDocumentoMedico)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(e => e.FechaGeneracion)
            .HasColumnName("FechaGeneracion")
            .IsRequired();

        builder.Property(e => e.Diagnostico)
            .HasColumnName("Diagnostico")
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(e => e.Origen)
            .HasColumnName("Origen")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.Clasificacion)
            .HasColumnName("Clasificacion")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.FechaInicio)
            .HasColumnName("FechaInicio")
            .IsRequired();

        builder.Property(e => e.FechaFin)
            .HasColumnName("FechaFin")
            .IsRequired();

        builder.Property(e => e.DuracionDias)
            .HasColumnName("DuracionDias")
            .IsRequired();

        builder.Property(e => e.NumeroPrescripcionSustituida)
            .HasColumnName("NumeroPrescripcionSustituida")
            .HasMaxLength(50)
            .IsRequired(false);
    }
}
