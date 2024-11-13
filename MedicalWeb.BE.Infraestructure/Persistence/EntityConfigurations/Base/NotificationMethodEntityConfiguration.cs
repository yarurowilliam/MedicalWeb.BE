using MedicalWeb.BE.Infraestructure.Data;
using MedicalWeb.BE.Transversales.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalWeb.BE.Infraestructure.Persistence.EntityConfigurations.Core;

public class NotificationMethodEntityConfiguration : IEntityTypeConfiguration<NotificationMethod>
{
    public void Configure(EntityTypeBuilder<NotificationMethod> builder)
    {
        builder.ToTable(
                DbConstants.Tables.NotificationMethods,
                DbConstants.Schemas.Dbo)
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Code)
            .HasMaxLength(DbConstants.StringLength.Code)
            .IsRequired();

        builder
            .HasIndex(x => x.Code)
            .IsUnique();
    }
}