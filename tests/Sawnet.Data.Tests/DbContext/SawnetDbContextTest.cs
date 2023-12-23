using FluentAssertions;
using Sawnet.Core.Contracts;
using Sawnet.Data.Tests.Models;

namespace Sawnet.Data.Tests.DbContext;

public class SawnetDbContextTest : TestingTest
{
    public SawnetDbContextTest(TestingDbFixture fixture) : base(fixture)
    {
    }

    [Fact]
    public async Task Should_Dispatch_Domain_Events()
    {
        var repository = GetRequiredService<IRepository<SampleAggregate, SampleId>>();

        await FluentActions
            .Awaiting(async () => await repository.InsertAsync(SampleAggregate.Create(SampleId.Create(Guid.NewGuid()))))
            .Should()
            .NotThrowAsync();
    }
}