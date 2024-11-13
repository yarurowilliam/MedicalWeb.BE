namespace MedicalWeb.BE.Transversales.Entidades;

public class NaturalPerson : Person
{
    public string Name { get; set; }
    public string FirstSurname { get; set; }
    public string LastSurname { get; set; }

    public override string GetFullName() => ($"{Name} {FirstSurname} "
                + (string.IsNullOrWhiteSpace(LastSurname) ? "" : LastSurname)).Trim();
}
