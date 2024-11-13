namespace MedicalWeb.BE.Transversales.Entidades;

public class LegalPerson : Person
{
    public string BusinessName { get; set; }
    public DateTime ConstitutionDate { get; set; }

    public Guid SectorId { get; set; }
    public Sector Sector { get; set; }

    public Guid? LegalRepresentativeId { get; set; }

    public override string GetFullName() => BusinessName;
}
