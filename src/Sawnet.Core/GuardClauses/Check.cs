namespace Sawnet.Core.GuardClauses;

public static partial class Check
{
    public static int CheckRange(int value, int minValue, int maxValue)
    {
        if (value < minValue || value > maxValue)
        {
            throw new ArgumentOutOfRangeException(nameof(value),
                $"The number must be between {minValue} and {maxValue}.");
        }

        return value;
    }

    public static decimal CheckRange(decimal value, decimal minValue, decimal maxValue)
    {
        if (value < minValue || value > maxValue)
        {
            throw new ArgumentOutOfRangeException(nameof(value),
                $"The number must be between {minValue} and {maxValue}.");
        }

        return value;
    }
}