using MedicalWeb.BE.Infraestructure.Data;
using MedicalWeb.BE.Transversales;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MedicalWeb.BE.Infraestructure.Persistence.EntityConfiguration;
public class EstadoAlertaEntityConfiguration : IEntityTypeConfiguration<EstadoAlerta>
{
    public void Configure(EntityTypeBuilder<EstadoAlerta> builder)
    {        
        builder.ToTable(
                DbConstants.Tables.EstadoAlerta,
                DbConstants.Schemas.Dbo)
            .HasKey(x => x.Id); 
       
        builder
            .Property(x => x.EstadoName)
            .HasMaxLength(DbConstants.StringLength.Names) 
            .IsRequired(); 
       
        builder
            .HasIndex(x => x.EstadoName)
            .IsUnique();
    }
}