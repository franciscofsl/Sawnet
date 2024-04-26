using FluentAssertions;
using NSubstitute;
using Quartz;
using Sawnet.Core.Contracts;
using Sawnet.Data.Tests.DbContext;
using Sawnet.Data.Tests.Types.Models;
using Sawnet.Infrastructure.BackgroundJobs;

namespace Sawnet.Data.Tests;

public class SawnetDbContextTest : TestingTest
{
    public SawnetDbContextTest(TestingDbFixture fixture) : base(fixture)
    {
    }

    [Fact]
    public async Task Should_Dispatch_Domain_Events_With_Outbox()
    {
        var repository = GetRequiredService<IRepository<SampleAggregate, SampleId>>();

        var aggregate = SampleAggregate.Create();

        aggregate.Processed.Should().BeFalse();

        await repository.InsertAsync(aggregate);

        var processor = GetRequiredService<ProcessOutboxMessagesJob>();

        var mock = Substitute.For<IJobExecutionContext>();
        mock.CancellationToken.Returns(new CancellationToken());
        
        await processor.Execute(mock);

        var createdAggregate = await repository.GetAsync(aggregate.Id);

        createdAggregate.Processed.Should().BeTrue();
    }
}