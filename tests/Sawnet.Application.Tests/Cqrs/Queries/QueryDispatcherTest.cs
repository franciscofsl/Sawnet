using Sawnet.Application.Cqrs.Queries;

namespace Sawnet.Application.Tests.Cqrs.Queries;

public class QueryDispatcherTest
{
    [Fact]
    public async Task Should_Dispatch_Query()
    {
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddTransient<IQueryHandler<CustomQuery, bool>, CustomQueryHandler>();

        var serviceProvider = serviceCollection.BuildServiceProvider();

        var queryDispatcher = new QueryDispatcher(serviceProvider);

        var result = await queryDispatcher.Dispatch(new CustomQuery());
        result.Should().BeTrue();
    }

    public record CustomQuery : IQuery<bool>;

    public class CustomQueryHandler : IQueryHandler<CustomQuery, bool>
    {
        public Task<bool> Handle(CustomQuery Query, CancellationToken token = default)
        {
            return Task.FromResult(true);
        }
    }
}