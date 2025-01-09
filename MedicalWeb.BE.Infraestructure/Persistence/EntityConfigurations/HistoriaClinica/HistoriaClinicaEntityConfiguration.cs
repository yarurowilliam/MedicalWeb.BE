using MedicalWeb.BE.Infraestructure.Data;
using MedicalWeb.BE.Transversales.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalWeb.BE.Infraestructure.Persistence.EntityConfigurations
{
    public class HistoriaClinicaVirtualEntityConfiguration : IEntityTypeConfiguration<HistoriaClinica>
    {
        public void Configure(EntityTypeBuilder<HistoriaClinica> builder)
        {
            builder.ToTable(
                DbConstants.Tables.HistoriaClinica,
                DbConstants.Schemas.Dbo);

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("Id")
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
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(e => e.FechaConsulta)
                .HasColumnName("FechaConsulta")
                .IsRequired();

            builder.Property(e => e.MotivoConsulta)
                .HasColumnName("MotivoConsulta")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(e => e.Alergias)
                .HasColumnName("Alergias")
                .HasMaxLength(200);

            builder.Property(e => e.MedicamentosActuales)
                .HasColumnName("MedicamentosActuales")
                .HasMaxLength(200);

            builder.Property(e => e.AntecedentesFamiliares)
                .HasColumnName("AntecedentesFamiliares")
                .HasMaxLength(200);

            builder.Property(e => e.AntecedentesPersonales)
                .HasColumnName("AntecedentesPersonales")
                .HasMaxLength(200);

            builder.Property(e => e.Sintomas)
                .HasColumnName("Sintomas")
                .HasMaxLength(200);

            builder.Property(e => e.ObservacionesMedicas)
                .HasColumnName("ObservacionesMedicas")
                .HasMaxLength(200);

            builder.Property(e => e.DiagnosticoPrincipal)
                .HasColumnName("DiagnosticoPrincipal")
                .HasMaxLength(200);

            builder.Property(e => e.PlanTratamiento)
                .HasColumnName("PlanTratamiento")
                .HasMaxLength(200);

            builder.Property(e => e.MedicamentosRecetados)
                .HasColumnName("MedicamentosRecetados")
                .HasMaxLength(200);

            builder.Property(e => e.Dosis)
                .HasColumnName("Dosis")
                .HasMaxLength(200);

            builder.Property(e => e.DuracionTratamiento)
                .HasColumnName("DuracionTratamiento")
                .HasMaxLength(100);

            builder.Property(e => e.EstadoActivo)
                .HasColumnName("EstadoActivo")
                .HasMaxLength(1)
                .IsRequired();
        }
    }
}
