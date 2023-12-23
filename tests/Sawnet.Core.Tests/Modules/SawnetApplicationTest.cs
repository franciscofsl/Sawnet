namespace Sawnet.Core.Tests.Modules;

public class SawnetApplicationTest
{
    [Fact]
    public void AddSawnetApplication_Should_Return_Application()
    {
        var serviceCollection = new ServiceCollection();

        var application = serviceCollection.AddSawnetApplication<FakeApplication>();

        application.Should().NotBeNull();
    }

    [ModulesToInclude(typeof(FakeModule))]
    private class FakeApplication : SawnetApplication
    {
        
    }

    private class FakeModule : SawnetModule
    {
        
    }
}