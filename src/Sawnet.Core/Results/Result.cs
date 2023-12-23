namespace Sawnet.Core.Results;

public class Result
{
    protected internal Result(bool success, Error error)
    {
        switch (success)
        {
            case true when error != Error.None:
                throw new InvalidOperationException();
            case false when error == Error.None:
                throw new InvalidOperationException();
            default:
                Success = success;
                Error = error;
                break;
        }
    }

    public bool Success { get; }

    public bool IsFailure => !Success;

    public Error Error { get; }

    public static Result Ok() => new(true, Error.None);

    public static Result<TValue> Ok<TValue>(TValue value) => new(value, true, Error.None);

    public static Result Failure(Error error) => new(false, error);

    public static Result<TValue> Failure<TValue>(Error error) => new(default, false, error);
}