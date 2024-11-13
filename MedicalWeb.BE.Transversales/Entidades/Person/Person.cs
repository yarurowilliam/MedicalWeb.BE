using MedicalWeb.BE.Transversales.Common;

namespace MedicalWeb.BE.Transversales.Entidades;

public abstract class Person : Entity, IAuditable, ISoftDeletable
{

    public string Email { get; set; }
    public string Phone { get; set; }
    public string IdentificationNumber { get; set; }
    public int PersonTypeId { get; set; }
    public PersonType PersonType { get; set; }
    public bool IsDeleted { get; set; }
    public abstract string GetFullName();
}