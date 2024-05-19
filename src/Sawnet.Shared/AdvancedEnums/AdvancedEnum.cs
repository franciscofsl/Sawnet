namespace Sawnet.Shared.AdvancedEnums;

public abstract class AdvancedEnum<TEnum, TId>
    where TEnum : AdvancedEnum<TEnum, TId>
{
    protected AdvancedEnum(TId id, string name, string color)
    {
        Id = id;
        Name = name;
        Color = color;
    }

    protected AdvancedEnum(TId id, string name) : this(id, name, null)
    {
    }

    public TId Id { get; }

    public string Name { get; }

    public string Color { get; }

    public override string ToString() => Name;
}