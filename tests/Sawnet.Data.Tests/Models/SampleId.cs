using Sawnet.Core.BaseTypes;

namespace Sawnet.Data.Tests.Models;

public record SampleId : EntityId
{
    public static SampleId Create(Guid value)
    {
        return new SampleId { Value = value };
    }

    public static explicit operator SampleId(Guid id) => Create(id);

    public static implicit operator Guid(SampleId id) => id.Value;
}