using MedicalWeb.BE.Infraestructure.Data;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MedicalWeb.BE.Transversales.Entidades;

namespace MedicalWeb.BE.Infraestructure.Persistence.EntityConfigurations;

public class AlertaEntityConfiguration : IEntityTypeConfiguration<Alerta>
{
    public void Configure(EntityTypeBuilder<Alerta> builder)
    {
        builder.ToTable(
                DbConstants.Tables.Alerta,
                DbConstants.Schemas.Dbo)
            .HasKey(x => x.IdAlerta);


        builder
            .Property(x => x.IdUsuario)
            .HasMaxLength(20)
            .IsRequired();

        builder
            .HasOne(x => x.Usuario)
            .WithMany()
            .HasForeignKey(x => x.IdUsuario)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .Property(x => x.Comentario)
            .HasMaxLength(DbConstants.StringLength.comment)
            .IsRequired();
        
        builder
            .HasOne(x => x.Estado)  
            .WithMany()              
            .HasForeignKey(x => x.EstadoAlertaId)  
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasIndex(x => x.IdUsuario)
            .IsUnique(false);
    }
}