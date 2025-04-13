using MedicalWeb.BE.Infraestructure.Data;
using MedicalWeb.BE.Transversales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalWeb.BE.Infraestructure.Persistence.EntityConfigurations
{
    public class EstadoReporteEntityConfiguration : IEntityTypeConfiguration<EstadoReporte>
    {
        public void Configure(EntityTypeBuilder<EstadoReporte> builder)
        {
            builder.ToTable(
              DbConstants.Tables.EstadoReporte,
              DbConstants.Schemas.Dbo)
              .HasKey(x => x.EstadoReporteID);

            builder
                .Property(x => x.Code)
                .HasMaxLength(DbConstants.StringLength.EstateCode)
                .IsRequired();

            builder
                .HasIndex(x => x.Code)
                .IsUnique();
        }
    }
}