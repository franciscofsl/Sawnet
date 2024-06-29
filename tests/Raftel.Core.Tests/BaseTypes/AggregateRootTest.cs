namespace Raftel.Core.Tests.BaseTypes;

public class AggregateRootTest
{
    [Fact]
    public void Constructor_WithValidId_Should_Set_Id()
    {
        var entityId = EntityTest.TestEntityId.Create(Guid.NewGuid());

        var aggregateRoot = TestAggregateRoot.Create(entityId);

        aggregateRoot.Id.Should().Be(entityId);
    }

    [Fact]
    public void RaiseDomainEvent_Should_Add_Event_To_Events_List()
    {
        var aggregateRoot = TestAggregateRoot.Create(EntityTest.TestEntityId.Create(Guid.NewGuid()));
        var domainEvent = new TestDomainEvent();

        InvokeRaiseDomainEvent(aggregateRoot, domainEvent);

        aggregateRoot.Events.Should().Contain(domainEvent);
    }

    [Fact]
    public void ClearDomainEvents_Should_Clear_Events_List()
    {
        var aggregateRoot = TestAggregateRoot.Create(EntityTest.TestEntityId.Create(Guid.NewGuid()));

        InvokeRaiseDomainEvent(aggregateRoot, new TestDomainEvent());
        aggregateRoot.ClearDomainEvents();

        aggregateRoot.Events.Should().BeEmpty();
    }

    [Fact]
    public void Should_Create_Aggregate_Root_With_Empty_Builder()
    {
        var aggregateRoot = TestAggregateRoot.Create(EntityTest.TestEntityId.Create(Guid.NewGuid()));
        aggregateRoot.Should().NotBeNull();
    }

    private static void InvokeRaiseDomainEvent(TestAggregateRoot aggregateRoot, TestDomainEvent domainEvent)
    {
        var methodInfo =
            typeof(AggregateRoot<EntityTest.TestEntityId>).GetMethod("RaiseDomainEvent",
                BindingFlags.Instance | BindingFlags.NonPublic);
        methodInfo.Invoke(aggregateRoot, new object[] { domainEvent });
    }

    private class TestAggregateRoot : AggregateRoot<EntityTest.TestEntityId>
    {
        private TestAggregateRoot()
        {
        }

        public static TestAggregateRoot Create(EntityTest.TestEntityId id)
        {
            return new TestAggregateRoot
            {
                Id = id
            };
        }
    }

    private class TestDomainEvent : IDomainEvent
    {
    }
}