using MedicalWeb.BE.Transversales.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace MedicalWeb.BE.Infraestructure.Persistence.EntityConfigurations;
public class ValoracionesEntityConfiguration : IEntityTypeConfiguration<Valoraciones>
{
    public void Configure(EntityTypeBuilder<Valoraciones> builder)
    {
        builder.ToTable("Valoraciones")
            .HasKey(x => x.id);

        builder.Property(x => x.id)
            .UseIdentityColumn();

        builder.Property(x => x.NumMedico)
            .HasMaxLength(50)
            .IsRequired();
        
        builder
            .HasOne<Medico>()
            .WithMany()
            .HasForeignKey(x => x.NumMedico)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.Valoracion)
            .IsRequired();
        
        builder.Property(x => x.Comentario)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(x => x.Estado)
            .IsRequired();

    }

}