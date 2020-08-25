using System;

namespace Viking.Macross.Interface
{
    public enum ErrorClass
    {
        Failure,
        Error,
        FatalError
    }

    public sealed class InvocationError
    {
        public InvocationError(string message, ErrorClass errorClass)
        {
            Message = message ?? throw new ArgumentNullException(nameof(message));
            ErrorClass = errorClass;
        }

        public string Message { get; }
        public ErrorClass ErrorClass { get; }
    }
}
