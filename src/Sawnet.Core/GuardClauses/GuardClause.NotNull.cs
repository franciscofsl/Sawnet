namespace Sawnet.Core.GuardClauses;

public static partial class GuardClause
{
    public static TObj NotNull<TObj>(TObj obj, string name)
    {
        if (obj is null)
        {
            throw new ArgumentNullException($"{name} must not be null");
        }
        return obj;
    }
}
