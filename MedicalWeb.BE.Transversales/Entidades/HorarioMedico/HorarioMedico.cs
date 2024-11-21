using System.Text.Json.Serialization;
using System.Text.Json;
namespace MedicalWeb.BE.Transversales.Entidades;

public class HorarioMedico
{
    public int Id { get; set; }
    public int DiaID { get; set; }
    public int HoraID { get; set; }
    public int EstadoHorarioID { get; set; }
    public string NumeroDocumento { get; set; }
    public string IdentificacionCliente { get; set; }

    [JsonConverter(typeof(JsonDateOnlyConverter))]
    public DateOnly Fecha { get; set; }
}

public class JsonDateOnlyConverter : JsonConverter<DateOnly>
{
    private const string Format = "dd-MM-yyyy";

    public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return DateOnly.ParseExact(reader.GetString()!, Format);
    }

    public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(Format));
    }
}