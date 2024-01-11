namespace Sawnet.Core.GuardClauses;

public static partial class Check
{
    public static TObj NotNull<TObj>(TObj obj, string name)
    {
        if (obj is null)
        {
            throw new ArgumentNullException(name);
        }
        return obj;
    }
}
