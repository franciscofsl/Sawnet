namespace Raftel.Blazor.Common;

public static class ReflexionExtensions
{
    public static object GetPropertyValue<TItem>(this TItem @this, string propertyName)
    {
        var property = typeof(TItem).GetProperty(propertyName);

        return property?.GetValue(@this);
    }

    public static void SetPropertyValue<TItem>(this TItem @this, string propertyName, object value)
    {
        var type = typeof(TItem);

        var property = type.GetProperty(propertyName);

        property?.SetValue(@this, value);
    }
}