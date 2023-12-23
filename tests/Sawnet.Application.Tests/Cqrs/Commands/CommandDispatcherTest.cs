namespace Sawnet.Application.Tests.Cqrs.Commands;

public class CommandDispatcherTest
{
    [Fact]
    public async Task Should_Dispatch_Command()
    {
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddTransient<ICommandHandler<CustomCommand, bool>, CustomCommandHandler>();

        var serviceProvider = serviceCollection.BuildServiceProvider();

        var commandDispatcher = new CommandDispatcher(serviceProvider);

        var result = await commandDispatcher.Dispatch(new CustomCommand());
        result.Should().BeTrue();
    }

    public record CustomCommand : ICommand<bool>;

    public class CustomCommandHandler : ICommandHandler<CustomCommand, bool>
    {
        public Task<bool> Handle(CustomCommand command, CancellationToken token = default)
        {
            return Task.FromResult(true);
        }
    }
}