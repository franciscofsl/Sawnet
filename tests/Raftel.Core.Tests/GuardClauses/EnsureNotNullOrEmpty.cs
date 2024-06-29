using Raftel.Core.GuardClauses;

namespace Raftel.Core.Tests.GuardClauses;

public class EnsureNotNullOrEmpty
{
    [Fact]
    public void Should_Return_Not_Null_String()
    {
        var anyStringObject = "Testing";

        var value = Ensure.NotNullOrEmpty(anyStringObject, nameof(anyStringObject));

        value.Should().Be(anyStringObject);
    }

    [Fact]
    public void Should_Return_Not_Empty_String()
    {
        var anyStringObject = "Testing";

        var value = Ensure.NotNullOrEmpty(anyStringObject, nameof(anyStringObject));

        value.Should().Be(anyStringObject);
    }

    [Fact]
    public void Should_Throw_Exception_With_Null_String()
    {
        string anyStringObject = null;

        FluentActions.Invoking(() => Ensure.NotNullOrEmpty(anyStringObject, nameof(anyStringObject)))
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Value cannot be null. (Parameter 'anyStringObject')");
    }

    [Fact]
    public void Should_Throw_Exception_With_Empty_String()
    {
        var anyStringObject = string.Empty;

        FluentActions.Invoking(() => Ensure.NotNullOrEmpty(anyStringObject, nameof(anyStringObject)))
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("anyStringObject must not be empty");
    }
}