using MedicalWeb.BE.Infraestructure.Data;
using MedicalWeb.BE.Transversales.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalWeb.BE.Infraestructure.Persistence.EntityConfigurations
{
    public class MedicionEntityConfiguration : IEntityTypeConfiguration<Medicion>
    {
        public void Configure(EntityTypeBuilder<Medicion> builder)
        {
            builder.ToTable(
                DbConstants.Tables.Medicion,
                DbConstants.Schemas.Dbo);

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(e => e.NumeroDocumento)
                .HasColumnName("NumeroDocumento")
                .HasMaxLength(20)
                .IsRequired();

            builder.HasOne<Pacientes>()
                .WithMany()
                .HasForeignKey(e => e.NumeroDocumento)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(e => e.Peso)
                .HasColumnName("Peso")
                .HasColumnType("decimal(10,2)") 
                .IsRequired();

            builder.Property(e => e.Altura)
                .HasColumnName("Altura")
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.Property(e => e.FechaRegistro)
                .HasColumnName("FechaRegistro")
                .IsRequired();
        }
    }
}