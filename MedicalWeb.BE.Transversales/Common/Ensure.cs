using MedicalWeb.BE.Transversales.Core.Exceptions;
using System.Diagnostics.CodeAnalysis;

#nullable enable

public static class Ensure
{
    public static void That(bool condition, string message = "")
    {
        That<Exception>(condition, message);
    }

    public static void That<TException>(bool condition, string message = "")
        where TException : Exception, new()
    {
        if (!condition)
        {
            throw (TException)Activator.CreateInstance(typeof(TException), message)!;
        }
    }

    public static void That<TException>(bool condition, string? message = null, string code = "")
        where TException : DomainException, new()
    {
        if (!condition)
        {
            throw (TException)Activator.CreateInstance(typeof(TException), message ?? code, code)!;
        }
    }

    public static void NotNull([NotNull] object? value, string message = "")
    {
        NotNull<NotFoundException>(value, message);
    }

    public static void NotNull<TException>([NotNull] object? value, string message = "")
         where TException : Exception, new()
    {
        if (value is null)
        {
            throw (TException)Activator.CreateInstance(typeof(TException), message)!;
        }
    }

    public static void NotNullOrEmpty([NotNull] string? value, string message = "String cannot be null or empty")
    {
        NotNullOrEmpty(value, message);
    }

    public static void NotNullOrEmpty<TException>([NotNull] string? value, string message = "String cannot be null or empty")
        where TException : Exception, new()
    {
        if (string.IsNullOrEmpty(value))
        {
            throw (TException)Activator.CreateInstance(typeof(TException), message)!;
        }
    }
}
