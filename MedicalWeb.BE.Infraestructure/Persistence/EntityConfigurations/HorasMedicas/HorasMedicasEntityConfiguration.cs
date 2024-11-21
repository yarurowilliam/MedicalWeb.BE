using MedicalWeb.BE.Infraestructure.Data;
using MedicalWeb.BE.Transversales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MedicalWeb.BE.Infraestructure.Persistence.EntityConfigurations;

public class HorasMedicasEntityConfiguration : IEntityTypeConfiguration<HorasMedicas>
{
    public void Configure(EntityTypeBuilder<HorasMedicas> builder)
    {
        builder.ToTable(
                DbConstants.Tables.HorasMedicas,
                DbConstants.Schemas.Dbo)
            .HasKey(x => x.HoraMedicaID);

        builder
            .Property(x => x.Code)
            .HasMaxLength(DbConstants.StringLength.EstateCode)
            .IsRequired();

        builder
            .HasIndex(x => x.Code)
            .IsUnique();
    }
}