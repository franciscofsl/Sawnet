﻿using Sawnet.Core.GuardClauses;


namespace Sawnet.Core.Tests.GuardClauses;

public class GuardClauseNotNullOrEmpty
{
    [Fact]
    public void Should_Return_Not_Null_String()
    {
        var anyStringObject = "Testing";

        var value = GuardClause.NotNullOrEmpty(anyStringObject, nameof(anyStringObject));

        value.Should().Be(anyStringObject);
    }

    [Fact]
    public void Should_Return_Not_Empty_String()
    {
        var anyStringObject = "Testing";

        var value = GuardClause.NotNullOrEmpty(anyStringObject, nameof(anyStringObject));

        value.Should().Be(anyStringObject);
    }

    [Fact]
    public void Should_Throw_Exception_With_Null_String()
    {
        string anyStringObject = null;

        FluentActions.Invoking(() => GuardClause.NotNullOrEmpty(anyStringObject, nameof(anyStringObject)))
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Value cannot be null. (Parameter 'anyStringObject must not be null')");
    }

    [Fact]
    public void Should_Throw_Exception_With_Empty_String()
    {
        var anyStringObject = string.Empty;

        FluentActions.Invoking(() => GuardClause.NotNullOrEmpty(anyStringObject, nameof(anyStringObject)))
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("anyStringObject must not be empty");
    }
}