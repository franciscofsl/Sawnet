namespace Sawnet.Core.GuardClauses;

public static partial class GuardClause
{
    public static string NotNullOrEmpty(string title, string name)
    {
        NotNull(title, name);
        if (string.IsNullOrEmpty(title))
        {
            throw new ArgumentException($"{name} must not be empty");
        }

        return title;
    }
}