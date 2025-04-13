using MedicalWeb.BE.Transversales.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalWeb.BE.Infraestructure.EntityConfiguration
{
    public class DesactivacionMedicoConfiguration : IEntityTypeConfiguration<DesactivacionMedico>
    {
        public void Configure(EntityTypeBuilder<DesactivacionMedico> builder)
        {
            builder.ToTable("DesactivacionMedico");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Id)
                .UseIdentityColumn();

            builder.Property(d => d.NumeroDocumento)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(d => d.FechaInicio)
                .IsRequired();

            builder.Property(d => d.FechaFin)
                .IsRequired(false);

            builder.Property(d => d.Motivo)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(d => d.Estado)
                .IsRequired()
                .HasMaxLength(1);

            builder.HasOne<Medico>()
                .WithMany()
                .HasForeignKey(d => d.NumeroDocumento)
                .HasPrincipalKey(m => m.NumeroDocumento)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}