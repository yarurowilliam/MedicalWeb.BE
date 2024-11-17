using MedicalWeb.BE.Infraestructure.Data;
using MedicalWeb.BE.Transversales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MedicalWeb.BE.Infraestructure.Persistence.EntityConfigurations;
public class EstadoHorarioEntityConfiguration : IEntityTypeConfiguration<EstadoHorarioMedico>
{
    public void Configure(EntityTypeBuilder<EstadoHorarioMedico> builder)
    {
        builder.ToTable(
            DbConstants.Tables.EstadoHorario,
            DbConstants.Schemas.Dbo)
            .HasKey(x => x.EstadoHorarioID);

        builder.Property(x => x.Code)
            .HasMaxLength(DbConstants.StringLength.EstateCode)
            .IsRequired();
        
        builder
            .HasIndex(x => x.Code)
            .IsUnique();

        builder.
            HasKey(x => x.EstadoHorarioID);

        builder.HasData(EstadoHorarioMedico.GetAll());
    }
}