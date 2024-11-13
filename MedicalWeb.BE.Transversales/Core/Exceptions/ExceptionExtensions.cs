using System.Text.Json;

namespace MedicalWeb.BE.Transversales.Core.Exceptions;

public record ExceptionExtensions<T> where T : class
{
    private static readonly JsonSerializerOptions _serializerOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);

    private T _value;

    public ExceptionExtensions(T value)
    {
        _value = value;
    }

    public IDictionary<string, object> ToDictionary()
    {
        var serializedValue = JsonSerializer.Serialize(_value, _serializerOptions);
        return JsonSerializer.Deserialize<Dictionary<string, object>>(serializedValue, _serializerOptions);
    }

    public static T FromDictionary(IDictionary<string, object> extensions)
    {
        var serializedExtension = JsonSerializer.Serialize(extensions, _serializerOptions);
        return JsonSerializer.Deserialize<T>(serializedExtension, _serializerOptions);
    }
}
