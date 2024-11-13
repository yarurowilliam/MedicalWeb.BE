using MedicalWeb.BE.Transversales.Core.Exceptions;

namespace MedicalWeb.BE.Transversales;

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
            throw (TException)Activator.CreateInstance(typeof(TException), message);
        }
    }

    public static void That<TException>(bool condition, string message = null, string code = "", IDictionary<string, object> extensions = default)
        where TException : DomainException, new()
    {
        if (!condition)
        {
            var exception = (TException)Activator.CreateInstance(typeof(TException), message ?? code, code);
            if (extensions is not null)
            {
                exception.Extensions = extensions;
            }
            throw exception;
        }
    }

    public static void That<TException, TExtensionsValue>(bool condition, string message = null, string code = "", TExtensionsValue extensions = default)
        where TException : DomainException, new()
        where TExtensionsValue : class
    {
        if (!condition)
        {
            var exception = (TException)Activator.CreateInstance(typeof(TException), message ?? code, code);
            if (extensions is not null)
            {
                exception.Extensions = new ExceptionExtensions<TExtensionsValue>(extensions)?.ToDictionary();
            }
            throw exception;
        }
    }

    public static void NotNull(object? value, string message = "")
    {
        That<NullReferenceException>(value != null, message);
    }

    public static void NotNull<TException>(object? value, string message = "")
         where TException : Exception, new()
    {
        That<TException>(value != null, message);
    }

    public static void NotNullOrEmpty(string value, string message = "String cannot be null or empty")
    {
        That(!string.IsNullOrEmpty(value), message);
    }

    public static void NotNullOrEmpty<TException>(string value, string message = "String cannot be null or empty")
        where TException : Exception, new()
    {
        That<TException>(!string.IsNullOrEmpty(value), message);
    }

    public static class Argument
    {
        public static void NotNull(object value, string paramName = "")
        {
            That<ArgumentNullException>(value != null, paramName);
        }

        public static void NotNullOrEmpty(string value, string paramName = "")
        {
            if (value == null)
            {
                throw new ArgumentNullException(paramName, "String value cannot be null");
            }

            if (string.Empty.Equals(value))
            {
                throw new ArgumentException("String value cannot be empty", paramName);
            }
        }
    }

}
