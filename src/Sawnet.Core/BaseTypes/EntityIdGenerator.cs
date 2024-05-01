using Sawnet.Shared.GuidGenerators;

namespace Sawnet.Core.BaseTypes;

public static class EntityIdGenerator
{
    public static TId Create<TId>() where TId : EntityId, new()
    {
        return new TId
        {
            Value = SequentialGuidGenerator.Create()
        };
    }
}