using Sawnet.Core.BaseTypes;

namespace Sawnet.Data.Tests.Models;

public class SampleAggregate : AggregateRoot<SampleId>
{
    private SampleAggregate()
    {
    }

    public static SampleAggregate Create(SampleId id)
    {
        var sample = new SampleAggregate
        {
            Id = id
        };

        sample.RaiseDomainEvent(new SampleModelCreated(sample));

        return sample;
    }
}