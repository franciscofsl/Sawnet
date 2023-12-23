namespace Sawnet.Core.Tests.BaseTypes;

public record TestValueObject : ValueObject
{
    private int _atomicValue = 42;

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return _atomicValue;
    }

    public void Increment()
    {
        // Simulate modification of atomic value for testing inequality
        _atomicValue++;
    }
}