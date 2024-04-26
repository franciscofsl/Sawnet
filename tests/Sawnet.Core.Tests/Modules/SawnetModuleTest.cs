using Sawnet.Shared.Modules;

namespace Sawnet.Core.Tests.Modules;

public class SawnetModuleTest
{
    [Fact]
    public void ConfigureCustomServices_Should_Not_Throw_Exception()
    {
        var module = new TestSawnetModule();

        FluentActions
            .Invoking(() => module.ConfigureCustomServices(new ServiceCollection()))
            .Should()
            .NotThrow();
    }

    [Fact]
    public void ConfigureServices_Should_Not_Throw_Exception()
    {
        var module = new TestSawnetModule();

        FluentActions
            .Invoking(() => module.ConfigureServices(new ServiceCollection()))
            .Should()
            .NotThrow();
    }

    [Fact]
    public void GetModules_With_Modules_To_Include_Attribute_Returns_Modules()
    {
        var module = new TestSawnetModuleWithAttribute();

        var modules = module.GetModules();

        modules.Should().NotBeNull();
        modules.Should().NotBeEmpty();
    }

    [Fact]
    public void ConfigureServices_Should_Not_Throw_Exception_With_Other_Module()
    {
        var module = new TestSawnetModuleWithAttribute();

        FluentActions
            .Invoking(() => module.ConfigureServices(new ServiceCollection()))
            .Should()
            .NotThrow();
    }

    [Fact]
    public void GetModules_Without_Modules_To_Include_Attribute_Returns_Empty_List()
    {
        var module = new TestSawnetModule();

        var modules = module.GetModules();

        modules.Should().BeEmpty();
    }

    private class TestSawnetModule : SawnetModule
    {
    }

    [ModulesToInclude(typeof(TestSawnetModule))]
    private class TestSawnetModuleWithAttribute : SawnetModule
    {
    }
}