using System.Runtime.Serialization;

namespace Sawnet.Blazor.Shared.Grpc.Filters;

[DataContract]
public class PagedResult<TItem>
{
    [DataMember(Order = 1)] public List<TItem> Items { get; set; }
}