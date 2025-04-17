using MedicalWeb.BE.Infraestructure.Data;
using MedicalWeb.BE.Transversales.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class ChatMessageEntityConfiguration : IEntityTypeConfiguration<ChatMessage>
{
    public void Configure(EntityTypeBuilder<ChatMessage> builder)
    {
        builder.ToTable(
            DbConstants.Tables.ChatMessage,
            DbConstants.Schemas.Dbo);

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .UseIdentityColumn();

        builder.Property(e => e.HorarioMedicoId)
            .IsRequired();

        builder.Property(e => e.PacienteId)
            .IsRequired();

        builder.Property(e => e.Mensaje)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(e => e.FechaEnvio)
            .IsRequired();

        builder.Property(e => e.ArchivoUrl)
            .HasMaxLength(500)
            .IsRequired(false);

        builder.Property(e => e.EsMedico)
            .IsRequired();

        builder
            .HasOne<HorarioMedico>()
            .WithMany()
            .HasForeignKey(e => e.HorarioMedicoId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne<Pacientes>()
            .WithMany()
            .HasForeignKey(e => e.PacienteId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}