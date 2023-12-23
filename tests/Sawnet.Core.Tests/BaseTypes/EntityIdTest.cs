using Sawnet.Testing.Extensions;

namespace Sawnet.Core.Tests.BaseTypes;

public class EntityIdTest
{
    [Fact]
    public void Should_Return_Atomic_Values()
    {
        var expectedId = Guid.NewGuid();

        var entityId =  EntityTest.TestEntityId.Create(expectedId);

        entityId.Value.Should().Be(expectedId);

        foreach (var value in entityId.InvokeGetAtomicValues())
        {
            value.Should().NotBeNull();
        }
    }
}