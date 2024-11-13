namespace MedicalWeb.BE.Transversales.Core.Exceptions;

public class DomainException : Exception
{
    public string Code;
    public IDictionary<string, object> Extensions { get; set; }

    public DomainException()
    {

    }

    public DomainException(string message)
        : base(message)
    {
    }

    public DomainException(string message, string code)
            : base(message)
    {
        Code = code;
    }

    public DomainException(string message, Exception innerException)
        : base(message, innerException)
    {

    }

    public DomainException(string message, Exception innerException, string code)
        : this(message, innerException)
    {
        Code = code;
    }
}
