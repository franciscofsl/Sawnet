using System.Runtime.Serialization;

namespace Sawnet.Blazor.Shared.Grpc.Filters;

[DataContract]
public class EntityByIdFilter
{
    [DataMember(Order = 1)] public Guid Id { get; set; }
}