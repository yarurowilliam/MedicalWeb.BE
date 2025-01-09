namespace MedicalWeb.BE.Transversales.Entidades;

public class HistoriaClinica
{
    public int Id { get; set; }
    public string NumeroDocumentoPaciente { get; set; }
    public string NumeroDocumentoMedico { get; set; }
    public DateTime FechaConsulta { get; set; }
    public string MotivoConsulta { get; set; }
    public string Alergias { get; set; }
    public string MedicamentosActuales { get; set; }
    public string AntecedentesFamiliares { get; set; }
    public string AntecedentesPersonales { get; set; }
    public string Sintomas { get; set; }
    public string ObservacionesMedicas { get; set; }
    public string DiagnosticoPrincipal { get; set; }
    public string PlanTratamiento { get; set; }
    public string MedicamentosRecetados { get; set; }
    public string Dosis { get; set; }
    public string DuracionTratamiento { get; set; }
    public char EstadoActivo { get; set; }

    public Pacientes Paciente { get; set; }
    public Medico Medico { get; set; }
}
