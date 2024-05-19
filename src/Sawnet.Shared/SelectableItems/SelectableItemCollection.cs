using System.Runtime.Serialization;

namespace Sawnet.Shared.SelectableItems;

[ExcludeFromCodeCoverage]
[DataContract]
public class SelectableItemCollection<TId>
{
    [DataMember(Order = 1)]
    public IEnumerable<SelectableItem<TId>> Items { get; set; }
} 