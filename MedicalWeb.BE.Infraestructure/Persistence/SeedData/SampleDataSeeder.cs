using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalWeb.BE.Infraestructure.Persitence.SeedData;

public static class SampleDataSeeder
{
    public static async Task PopulateSamples(MedicalWebDbContext context)
    {
        ArgumentNullException.ThrowIfNull(context, nameof(context));
        context.Database.EnsureCreated();
    }
}