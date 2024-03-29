namespace Sawnet.Core.BaseTypes;

public abstract record EntityId
{
    public Guid Value { get; internal protected init; }

    protected IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}