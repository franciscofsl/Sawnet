namespace Sawnet.Shared.Results;

public class Result<TValue> : Result
{
    private readonly TValue _value;

    protected internal Result(TValue value, bool success, Error error)
        : base(success, error) =>
        _value = value;

    public TValue Value => Success
        ? _value!
        : throw new InvalidOperationException("The value of a failure result can not be accessed.");
}