    using MedicalWeb.BE.Infraestructure.Data;
using MedicalWeb.BE.Transversales;
using MedicalWeb.BE.Transversales.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalWeb.BE.Infraestructure.Persistence.EntityConfigurations;

public class HorarioMedicoEntityConfiguration : IEntityTypeConfiguration<HorarioMedico>
{
    public void Configure(EntityTypeBuilder<HorarioMedico> builder)
    {
        builder.ToTable(
                 DbConstants.Tables.HorarioMedico,
                 DbConstants.Schemas.Dbo)
             .HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .UseIdentityColumn();

        builder.Property(x => x.DiaID)
            .IsRequired();

        builder
           .HasOne<Dias> ()
           .WithMany() 
           .HasForeignKey(x => x.DiaID) 
           .OnDelete(DeleteBehavior.Restrict);


        builder.Property(x => x.Fecha)
            .IsRequired();  

        builder.Property(x => x.HoraID)
            .IsRequired();

        builder
            .HasOne<HorasMedicas>()
            .WithMany() 
            .HasForeignKey(x => x.HoraID)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.EstadoHorarioID)
            .IsRequired();

        builder
            .HasOne<EstadoHorarioMedico>()
            .WithMany()
            .HasForeignKey(x => x.EstadoHorarioID)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.NumeroDocumento)
            .HasMaxLength(DbConstants.StringLength.IdentificationNumber)
            .IsRequired();

        builder
           .HasOne<Medico>()
           .WithMany()
           .HasForeignKey(x => x.NumeroDocumento)
           .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.IdentificacionCliente)
            .HasMaxLength(DbConstants.StringLength.IdentificationNumber);

        //builder
        //    .HasOne<Usuario>() 
        //    .WithMany()      
        //    .HasForeignKey(x => x.IdentificacionCliente)
        //    .OnDelete(DeleteBehavior.Restrict);
    }
}