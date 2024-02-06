using Sawnet.Core.GuardClauses;

namespace Sawnet.Core.Tests.GuardClauses;

public class GuardClauseMaxLength
{
    [Fact]
    public void MaxLength_With_Valid_Length_Returns_Value()
    {
        var value = "Hello";
        var maxLength = 10;
        var name = "TestString";

        var result = Ensure.HasMaxLength(value, maxLength, name);

        result.Should().Be(value);
    }

    [Fact]
    public void MaxLength_With_Max_Length_Returns_Value()
    {
        var value = "Hello";
        var maxLength = 5;
        var name = "TestString";

        var result = Ensure.HasMaxLength(value, maxLength, name);

        result.Should().Be(value);
    }

    [Fact]
    public void MaxLength_With_Length_Exceeds_MaxLength_Throws_ArgumentException()
    {
        var value = "Hello";
        var maxLength = 3;
        var name = "TestString";

        FluentActions.Invoking(() => Ensure.HasMaxLength(value, maxLength, name))
            .Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"{name} cannot exceed {maxLength} characters. (Parameter 'value')");
    }

    [Fact]
    public void MaxLength_With_Null_Value_Throws_ArgumentNullException()
    {
        string value = null;
        var maxLength = 5;

        FluentActions.Invoking(() => Ensure.HasMaxLength(value, maxLength, "TestString"))
            .Should()
            .ThrowExactly<ArgumentNullException>()
            .WithMessage("Value cannot be null. (Parameter 'TestString')");
    }

    [Fact]
    public void MaxLength_With_Negative_MaxLength_Throws_ArgumentOutOfRangeException()
    {
        var value = "Hello";
        var maxLength = -5;
        var name = "TestString";

        FluentActions.Invoking(() => Ensure.HasMaxLength(value, maxLength, name))
            .Should()
            .ThrowExactly<ArgumentOutOfRangeException>()
            .WithMessage("MaxLength should be a non-negative value. (Parameter 'name')");
    }
}