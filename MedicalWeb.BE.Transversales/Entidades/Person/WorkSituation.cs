using MedicalWeb.BE.Transversales.Common;

namespace MedicalWeb.BE.Transversales.Entidades;

public class WorkSituation : EnumEntity
{
    public string Name { get; set; } = null!;

    public static IEnumerable<WorkSituation> GetAll() =>
        new List<WorkSituation>()
        {
            new WorkSituation { Id = 1, Name = "Empleado" },
            new WorkSituation { Id = 2, Name = "Independiente" },
            new WorkSituation { Id = 3, Name = "Desempleado" },
            new WorkSituation { Id = 4, Name = "Jubilado" },
            new WorkSituation { Id = 5, Name = "Estudiante" },
            new WorkSituation { Id = 6, Name = "Cuidador(a) del hogar" },
            new WorkSituation { Id = 7, Name = "Empleado público" },
            new WorkSituation { Id = 8, Name = "Pensionado" },
            new WorkSituation { Id = 9, Name = "Baja laboral" },
            new WorkSituation { Id = 10, Name = "Empleado a tiempo parcial" },
            new WorkSituation { Id = 11, Name = "Empleado eventual" },
            new WorkSituation { Id = 12, Name = "Empresario" },
            new WorkSituation { Id = 13, Name = "Prejubilado" },
            new WorkSituation { Id = 14, Name = "Trabajador en prácticas" },
            new WorkSituation { Id = 15, Name = "Otro" }
       };
}