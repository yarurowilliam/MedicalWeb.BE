using MedicalWeb.BE.Infraestructure.Data;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalWeb.BE.Transversales.Entidades;

namespace MedicalWeb.BE.Infraestructure.Persistence.EntityConfigurations;

public class RecetasEntityConfiguration: IEntityTypeConfiguration<Receta>
{

    public void Configure(EntityTypeBuilder<Receta> builder)
    {
        builder.ToTable(
            DbConstants.Tables.Recetas,
            DbConstants.Schemas.Dbo);

        builder.HasKey(e => e.ID);

        builder.Property(e => e.ID)
            .HasColumnName("ID")
            .IsRequired();

        builder.Property(e => e.NumeroDocumentoPaciente)
            .HasColumnName("NumeroDocumentoPaciente")
            .HasMaxLength(20)
            .IsRequired();

        // Relaciones
        builder.HasOne<Pacientes>()
            .WithMany()
            .HasForeignKey(e => e.NumeroDocumentoPaciente)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(e => e.NumeroDocumentoMedico)
            .HasColumnName("NumeroDocumentoMedico")
            .HasMaxLength(20)
            .IsRequired();

        builder
           .HasOne(x => x.Medico)
           .WithMany()
           .HasForeignKey(x => x.NumeroDocumentoMedico)
           .OnDelete(DeleteBehavior.NoAction);

        builder.Property(e => e.FechaHora)
            .HasColumnName("FechaHora")
            .IsRequired();

        builder.Property(e => e.Diagnostico)
            .HasColumnName("Diagnostico")
            .HasMaxLength(500)
            .IsRequired();       
    }
}
