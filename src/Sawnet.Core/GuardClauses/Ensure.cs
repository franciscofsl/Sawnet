namespace Sawnet.Core.GuardClauses;

public static class Ensure
{
    public static int InRange(int value, int minValue, int maxValue)
    {
        if (value < minValue || value > maxValue)
        {
            throw new ArgumentOutOfRangeException(nameof(value),
                $"The number must be between {minValue} and {maxValue}.");
        }

        return value;
    }

    public static decimal InRange(decimal value, decimal minValue, decimal maxValue)
    {
        if (value < minValue || value > maxValue)
        {
            throw new ArgumentOutOfRangeException(nameof(value),
                $"The number must be between {minValue} and {maxValue}.");
        }

        return value;
    }

    public static string HasMaxLength(string value, int maxLength, string name)
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

    public static TObj NotNull<TObj>(TObj obj, string name)
    {
        if (obj is null)
        {
            throw new ArgumentNullException(name);
        }

        return obj;
    }

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