namespace Raftel.Core.Tests.BaseTypes;

public class EntityTest
{
    [Fact]
    public void Should_Clear_Domain_Events()
    {
        var testEntity = TestEntity.Create(TestEntityId.Create(Guid.NewGuid()));

        testEntity.Events.Should().HaveCount(1);

        testEntity.ClearDomainEvents();

        testEntity.Events.Should().BeEmpty();
    }

    private class TestEntity : Entity<TestEntityId>
    {
        private TestEntity()
        {
        }

        public static TestEntity Create(TestEntityId id)
        {
            var testEntity = new TestEntity
            {
                Id = id
            };

            testEntity.RaiseDomainEvent(new TestDomainEvent());

            return testEntity;
        }
    }

    public record TestEntityId : EntityId
    {
        public static TestEntityId Create(Guid value)
        {
            return new TestEntityId
            {
                Value = value
            };
        }
    }

    private class TestDomainEvent : IDomainEvent
    {
    }
}