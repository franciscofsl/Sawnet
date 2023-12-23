namespace Sawnet.Core.Tests;

public class DddModuleTest
{
    [Fact]
    public void Ddd_Module_Should_Configure_Domain_Event_Publisher()
    {
        var serviceCollection = new ServiceCollection();
        var dddModule = new DddModule();
        dddModule.ConfigureCustomServices(serviceCollection);

        var serviceProvider = serviceCollection.BuildServiceProvider();
        var domainEventPublisher = serviceProvider.GetRequiredService<IDomainEventPublisher>();

        var domainEventPublisherIsValidType = domainEventPublisher is DomainEventPublisher;

        domainEventPublisherIsValidType.Should().BeTrue();
    }
}