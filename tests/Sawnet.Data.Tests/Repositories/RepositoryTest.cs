﻿using FluentAssertions;
using Sawnet.Core.Contracts;
using Sawnet.Core.Specifications;
using Sawnet.Data.Tests.DbContext;
using Sawnet.Data.Tests.Types.Models;

namespace Sawnet.Data.Tests.Repositories;

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