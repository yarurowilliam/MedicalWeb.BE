using MedicalWeb.BE.Infraestructure.Data;
using MedicalWeb.BE.Transversales.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalWeb.BE.Infraestructure.Persistence.EntityConfigurations;

public class MedicamentoRecetadoEntityConfiguration: IEntityTypeConfiguration<MedicamentoRecetado>
{
    public void Configure(EntityTypeBuilder<MedicamentoRecetado> builder)
    {
        builder.ToTable(
            DbConstants.Tables.MedicamentoRecetados,
            DbConstants.Schemas.Dbo);

        builder.HasKey(e => e.ID);

        builder.Property(e => e.ID)
            .HasColumnName("ID")
            .IsRequired();

        builder.Property(e => e.RecetaID)
            .HasColumnName("RecetaID")
            .IsRequired();

        builder.HasOne(m => m.Receta)
            .WithMany()
            .HasForeignKey(m => m.RecetaID);

        builder.Property(e => e.NombreMedicamento)
            .HasColumnName("NombreMedicamento")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.Concentracion)
            .HasColumnName("Concentracion")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.FormaFarmaceutica)
            .HasColumnName("FormaFarmaceutica")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.CantidadRecetada)
            .HasColumnName("CantidadRecetada")
            .IsRequired();

        builder.Property(e => e.InstruccionesUso)
            .HasColumnName("InstruccionesUso")
            .HasMaxLength(500)
            .IsRequired();
    }
}
