namespace Sawnet.Core.Exceptions;

public sealed class DomainException : Exception
{
    private readonly string _errorCode;

    public DomainException(string errorCode)
    {
        _errorCode = errorCode;
    }

    public override string Message => _errorCode;
}