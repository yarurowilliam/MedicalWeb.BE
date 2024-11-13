using MedicalWeb.BE.Transversales.Core;
using MedicalWeb.BE.Transversales;
using Microsoft.EntityFrameworkCore;
using MedicalWeb.BE.Transversales.Entidades;

namespace MedicalWeb.BE.Infraestructure.Persitence.SeedData;

public static partial class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        PopulateEnums(modelBuilder);
        //PopulateInitialMasters(modelBuilder);
        PopulateExternalMasters(modelBuilder);
    }

    private static void PopulateEnums(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DocumentationStatus>().HasData(DocumentationStatus.GetAll());
        modelBuilder.Entity<NotificationMethod>().HasData(NotificationMethod.GetAll());
    }

    //private static void PopulateInitialMasters(ModelBuilder modelBuilder)
    //{
    //}

    private static void PopulateExternalMasters(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>().HasData(Country.GetAll());
        modelBuilder.Entity<Nationality>().HasData(Nationality.GetAll());
        modelBuilder.Entity<WorkSituation>().HasData(WorkSituation.GetAll());
        modelBuilder.Entity<MaritalStatus>().HasData(MaritalStatus.GetAll());
    }
}
