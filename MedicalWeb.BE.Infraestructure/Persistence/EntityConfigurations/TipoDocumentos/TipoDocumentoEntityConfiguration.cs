using MedicalWeb.BE.Infraestructure.Data;
using MedicalWeb.BE.Transversales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace MedicalWeb.BE.Infraestructure.Persistence.EntityConfigurations.TipoDocumentos;

public class TipoDocumentoEntityConfiguration : IEntityTypeConfiguration<TipoDocumento>
{
    public void Configure(EntityTypeBuilder<TipoDocumento> builder)
    {
        builder.ToTable(
                DbConstants.Tables.TipoDocumento,
                DbConstants.Schemas.Dbo)
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Name)
            .HasMaxLength(DbConstants.StringLength.Names)
            .IsRequired();

        builder
            .HasIndex(x => x.Name)
            .IsUnique();
    }
}