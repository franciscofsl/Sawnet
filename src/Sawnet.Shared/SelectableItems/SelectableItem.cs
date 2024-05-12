namespace Sawnet.Shared.SelectableItems;

[ExcludeFromCodeCoverage]
public class SelectableItem : SelectableItem<Guid>
{
    public SelectableItem()
    {
    }
}

[ExcludeFromCodeCoverage]
public class SelectableItem<TId> : ISelectableItem
{
    public SelectableItem()
    {
    }

    public SelectableItem(TId id, string name)
    {
        Id = id;
        Name = name;
    }

    public TId Id { get; set; }
    public string Name { get; set; }

    public override bool Equals(object obj)
    {
        if (obj is SelectableItem<TId> other)
        {
            return Id.Equals(other.Id);
        }

        return false;
    }

    public override string ToString() => Name;
}