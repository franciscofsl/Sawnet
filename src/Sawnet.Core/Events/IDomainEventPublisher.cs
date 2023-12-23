namespace Sawnet.Core.Events;

public interface IDomainEventPublisher
{
    Task Publish(IDomainEvent domainEvent);
}