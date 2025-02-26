using MedicalWeb.BE.Infraestructure.Data;
using MedicalWeb.BE.Transversales.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalWeb.BE.Infraestructure.Persistence.EntityConfigurations;

public class CancelacionCitaEntityConfiguration : IEntityTypeConfiguration<CancelacionCita>
{
    public void Configure(EntityTypeBuilder<CancelacionCita> builder)
    {

        builder.ToTable(
            DbConstants.Tables.CancelacionCita,
            DbConstants.Schemas.Dbo);

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .UseIdentityColumn();

        builder.Property(e => e.CitaId)
            .IsRequired();

        builder.Property(e => e.NumDocumentoPaciente)
            .IsRequired();

        builder
            .HasOne<Pacientes>()
            .WithMany()
            .HasForeignKey(e => e.NumDocumentoPaciente)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne<HorarioMedico>()
            .WithMany()
            .HasForeignKey(e => e.CitaId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(e => e.Motivo)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(e => e.UsuarioQueCanceloId)
            .IsRequired();

        builder.Property(e => e.FechaCancelacion)
            .IsRequired();

    }
}
