namespace Sawnet.Shared.SelectableItems;

[ExcludeFromCodeCoverage]
public class SelectableItemCollection<TId>
{
    public IEnumerable<SelectableItem<TId>> Items { get; set; }
}

[ExcludeFromCodeCoverage]
public class SelectableItemCollection : SelectableItemCollection<Guid>
{
}