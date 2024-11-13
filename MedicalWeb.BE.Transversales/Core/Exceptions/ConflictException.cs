using MedicalWeb.BE.Transversales.Core.Exceptions;

namespace MedicalWeb.BE.Transversales.Domain.Core.Exceptions;

public class ConflictException : DomainException
{
    public ConflictException() { }
    public ConflictException(string message) : base(message) { }
    public ConflictException(string code, string message = null) : base(message, code) { }

    public ConflictException(string code, string message = null, object conflictDetails = null)
        : base(message, code)
    {
        Extensions = new Dictionary<string, object>
        {
            { ProblemDetailsExtensions.ConflictDetails, conflictDetails }
        };
    }
}
