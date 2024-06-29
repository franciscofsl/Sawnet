namespace Raftel.Core.Events;

public class DomainEventPublisher : IDomainEventPublisher
{
    private readonly IServiceProvider _serviceProvider;

    public DomainEventPublisher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task Publish(IDomainEvent domainEvent, CancellationToken contextCancellationToken)
    {
        var type = typeof(IDomainEventHandler<>).MakeGenericType(domainEvent.GetType());
        dynamic handler = _serviceProvider.GetService(type);
        CancellationToken token = default;
        if (handler is not null)
        {
            await handler.Handle((dynamic)domainEvent, token);
        }
    }
}