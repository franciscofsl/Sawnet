namespace Sawnet.Core.GuardClauses;

public partial class Check
{
    public static string MaxLength(string value, int maxLength, string name)
    {
        NotNullOrEmpty(value, name);

        if (maxLength < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(name), "MaxLength should be a non-negative value.");
        }

        if (value.Length > maxLength)
        {
            throw new ArgumentException($"{name} cannot exceed {maxLength} characters.", nameof(value));
        }

        return value;
    }
}