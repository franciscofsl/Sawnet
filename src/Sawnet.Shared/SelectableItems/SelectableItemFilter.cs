using System.Runtime.Serialization;

namespace Sawnet.Shared.SelectableItems;

[DataContract]
public class SelectableItemFilter
{
    [DataMember(Order = 1)] public string Filter { get; set; }
}