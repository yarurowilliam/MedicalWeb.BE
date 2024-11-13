using MedicalWeb.BE.Transversales.Common;

namespace MedicalWeb.BE.Transversales.Entidades;

public class Sector : Entity
{
    public string Value { get; set; }

    public virtual ICollection<LegalPerson> LegalPeople { get; set; } = new List<LegalPerson>();
}
