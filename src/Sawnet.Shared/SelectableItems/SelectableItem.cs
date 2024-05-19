using System.Runtime.Serialization;

namespace Sawnet.Shared.SelectableItems;

[ExcludeFromCodeCoverage]
[DataContract]
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

    [DataMember(Order = 1)] public TId Id { get; set; }

    [DataMember(Order = 2)] public string Name { get; set; }

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