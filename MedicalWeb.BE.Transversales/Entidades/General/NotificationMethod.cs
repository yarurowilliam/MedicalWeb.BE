using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalWeb.BE.Transversales.Entidades;

public sealed class NotificationMethod
{
    public static class NotificationMethodTypes
    {
        public const string Email = "EMAIL";
        public const string Whatsapp = "WHATSAPP";
    }

    public static readonly NotificationMethod Email = new(1, NotificationMethodTypes.Email);
    public static readonly NotificationMethod Whatsapp = new(2, NotificationMethodTypes.Whatsapp);

    public int Id { get; }
    public string Code { get; }

    private NotificationMethod(int id, string code)
    {
        Id = id;
        Code = code;
    }

    private NotificationMethod() { }

    public static NotificationMethod[] GetAll()
        => new[] {
            Email,
            Whatsapp,
        };

    public static bool IsValidCode(string code)
        => GetAll().Any(x => x.Code == code);

    public static NotificationMethod GetByCode(string code)
        => GetAll().First(x => x.Code == code);

    public static NotificationMethod GetById(int id)
        => GetAll().First(x => x.Id == id);
}
