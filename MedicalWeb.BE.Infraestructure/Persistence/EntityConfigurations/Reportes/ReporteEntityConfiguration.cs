using MedicalWeb.BE.Infraestructure.Data;
using MedicalWeb.BE.Transversales;
using MedicalWeb.BE.Transversales.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalWeb.BE.Infraestructure.Persistence.EntityConfigurations
{
    public class ReporteEntityConfiguration : IEntityTypeConfiguration<Reporte>
    {
        public void Configure(EntityTypeBuilder<Reporte> builder)
        {
            builder.ToTable(
                DbConstants.Tables.Reporte,
                DbConstants.Schemas.Dbo)
                .HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn();

            builder.Property(x => x.Motivo)
                .IsRequired()
                .HasMaxLength(DbConstants.StringLength.Description);

            builder.Property(x => x.Mensaje)
                .IsRequired()
                .HasMaxLength(DbConstants.StringLength.Description); 

            builder.Property(x => x.Estado)
                .IsRequired();

            builder.HasOne<EstadoReporte>()
                .WithMany()
                .HasForeignKey(x => x.Estado)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.UsuarioId)
                .IsRequired();

            builder.Property(x => x.FechaCreacion)
                .IsRequired();

            builder.Property(x => x.Nombre)
                .IsRequired()
                .HasMaxLength(DbConstants.StringLength.Names);
        }
    }
}