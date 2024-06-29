using Raftel.Core.GuardClauses;

namespace Raftel.Core.Tests.GuardClauses;

public class EnsureNotNull
{
    [Fact]
    public void Should_Return_Not_Null_Object()
    {
        var anyStringObject = "Testing";

        var value = Ensure.NotNull(anyStringObject, nameof(anyStringObject));

        value.Should().Be(anyStringObject);
    }

    [Fact]
    public void Should_Throw_Exception_With_Null_Object()
    {
        string anyStringObject = null;

        FluentActions
            .Invoking(() => Ensure.NotNull(anyStringObject, nameof(anyStringObject)))
            .Should()
            .ThrowExactly<ArgumentNullException>()
            .WithMessage("Value cannot be null. (Parameter 'anyStringObject')");
    }
}