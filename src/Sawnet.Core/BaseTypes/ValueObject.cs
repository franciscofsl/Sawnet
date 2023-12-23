namespace Sawnet.Core.BaseTypes;

public abstract record ValueObject
{
    protected abstract IEnumerable<object> GetAtomicValues();

    public virtual bool Equals(ValueObject other)
    {
        if (other == null || other.GetType() != GetType())
        {
            return false;
        }

        return GetAtomicValues().SequenceEqual(other.GetAtomicValues());
    }

    public override int GetHashCode()
    {
        return GetAtomicValues().Aggregate(default(int), HashCode.Combine);
    }
}