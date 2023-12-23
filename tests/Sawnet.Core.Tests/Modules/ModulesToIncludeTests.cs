namespace Sawnet.Core.Tests.Modules;

public class ModulesToIncludeTests
{
    [Fact]
    public void Constructor_With_Valid_Module_Types_Creates_Modules_List()
    {
        var moduleType = typeof(TestSawnetModule);

        var attribute = new ModulesToIncludeAttribute(moduleType);

        attribute.Modules.Should().NotBeNull();
        attribute.Modules.Should().NotBeEmpty();
    }

    [Fact]
    public void Constructor_With_No_Module_Types_Throws_InvalidOperationException()
    {
        FluentActions.Invoking(() => new ModulesToIncludeAttribute())
            .Should()
            .Throw<InvalidOperationException>();
    }

    [ModulesToInclude(typeof(TestSawnetModule))]
    private class TestSawnetModule : SawnetModule
    {
        public override void ConfigureCustomServices(IServiceCollection services)
        {
            base.ConfigureCustomServices(services);
        }
    }
}