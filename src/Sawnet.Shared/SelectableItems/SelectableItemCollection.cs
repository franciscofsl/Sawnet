namespace Sawnet.Shared.SelectableItems;

public class SelectableItemCollection<TId>
{
    public IEnumerable<SelectableItem<TId>> Items { get; set; }
}

public class SelectableItemCollection : SelectableItemCollection<Guid>
{
}