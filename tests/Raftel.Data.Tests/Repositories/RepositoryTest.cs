using FluentAssertions;
using Raftel.Core.Contracts;
using Raftel.Core.Specifications;
using Raftel.Data.Tests.DbContext;
using Raftel.Data.Tests.Types.Models;

namespace Raftel.Data.Tests.Repositories;

public class RepositoryTest : TestingTest
{
    public RepositoryTest(TestingDbFixture fixture) : base(fixture)
    {
    }

    [Fact]
    public async Task Should_Use_Filter_To_Get_Items()
    {
        var repository = GetRequiredService<IRepository<SampleAggregate, SampleId>>();

        var entity = SampleAggregate.Create();

        await repository.InsertAsync(entity);

        var filter = Filter<SampleAggregate>.Create()
            .Where(_ => !_.Processed);
        
        var items = await repository.GetListAsync(filter);

        items.Should().Contain(_ => _.Id == entity.Id);
    }
}