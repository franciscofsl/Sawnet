using Sawnet.Core.Results;

namespace Sawnet.Core.Tests.Results;

public class ResultTest
{
    [Fact]
    public void Should_Not_Create_Ok_Result_With_Error()
    {
        FluentActions
            .Invoking(() => _ = new Result(true, new Error("Code", "Message")))
            .Should()
            .Throw<InvalidOperationException>();
    }

    [Fact]
    public void Should_Not_Create_Failure_With_None_Error()
    {
        FluentActions
            .Invoking(() => _ = new Result(false, Error.None))
            .Should()
            .Throw<InvalidOperationException>();
    }

    [Fact]
    public void Should_Create_Ok_Result()
    {
        var result = Result.Ok();

        result.Error.Should().Be(Error.None);
        result.IsFailure.Should().BeFalse();
    }

    [Fact]
    public void Should_Add_Error()
    {
        var result = Result.Failure(new Error("Code", "Message"));

        result.IsFailure.Should().BeTrue();
        result.Error.Should().NotBeNull();
    }

    [Fact]
    public void Generic_Ok_Result_Should_Have_Value_In_Parameter()
    {
        var result = Result.Ok(1);

        result.Value.Should().Be(1);
    }

    [Fact]
    public void Generic_Failure_Result_Should_Not_Have_Value_In_Parameter()
    {
        var result = Result.Failure<string>(new Error("Code", "Message"));

        FluentActions
            .Invoking(() => _ = result.Value)
            .Should()
            .Throw<InvalidOperationException>();
    }

    [Fact]
    public void Error_ToString_Should_Return_Code()
    {
        var error = new Error("Error", "Message");

        error.ToString().Should().Be(error.Code);
    }
}