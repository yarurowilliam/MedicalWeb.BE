using MedicalWeb.BE.Infraestructure.Data;
using MedicalWeb.BE.Transversales.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MedicalWeb.BE.Infraestructure.Persistence.EntityConfigurations;

public class MedicoEspecialidadEntityConfiguration : IEntityTypeConfiguration<MedicoEspecialidad>
{
    public void Configure(EntityTypeBuilder<MedicoEspecialidad> builder)
    {
        builder.ToTable(
                DbConstants.Tables.MedicoEspecialidad,
                DbConstants.Schemas.Dbo)
            .HasKey(x => x.Id);

        builder
            .Property(x => x.MedicoNumeroDocumento)
            .HasMaxLength(20)
            .IsRequired();

        builder
            .HasOne(x => x.Medico)  
            .WithMany()  
            .HasForeignKey(x => x.MedicoNumeroDocumento) 
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(x => x.Especialidad)  
            .WithMany()  
            .HasForeignKey(x => x.EspecialidadId) 
            .OnDelete(DeleteBehavior.NoAction);

    }
}