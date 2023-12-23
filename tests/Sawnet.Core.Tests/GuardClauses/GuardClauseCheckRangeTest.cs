using Sawnet.Core.GuardClauses;


namespace Sawnet.Core.Tests.GuardClauses;

public class GuardClauseCheckRangeTest
{
    [Fact]
    public void CheckRange_With_Valid_Range_Returns_Value()
    {
        var value = 5;
        var minValue = 1;
        var maxValue = 10;

        var result = GuardClause.CheckRange(value, minValue, maxValue);

        result.Should().Be(value);
    } 

    [Fact]
    public void CheckRange_With_Out_Of_Range_Value_Throws_ArgumentOutOfRangeException()
    {
        var value = 15;
        var minValue = 1;
        var maxValue = 10;

        FluentActions.Invoking(() => GuardClause.CheckRange(value, minValue, maxValue))
            .Should()
            .ThrowExactly<ArgumentOutOfRangeException>()
            .WithMessage($"The number must be between {minValue} and {maxValue}. (Parameter 'value')");
    }

    [Fact]
    public void CheckRange_With_Equal_Min_And_Max_Values_Returns_Value()
    {
        var value = 5;
        var minValue = 5;
        var maxValue = 5;

        var result = GuardClause.CheckRange(value, minValue, maxValue);

        result.Should().Be(value);
    }

    [Fact]
    public void CheckRange_With_Min_Value_Greater_Than_Max_Value_ThrowsArgumentException()
    {
        var value = 5;
        var minValue = 10;
        var maxValue = 5;

        FluentActions.Invoking(() => GuardClause.CheckRange(value, minValue, maxValue))
            .Should()
            .ThrowExactly<ArgumentOutOfRangeException>()
            .WithMessage("The number must be between 10 and 5. (Parameter 'value')");
    }
}