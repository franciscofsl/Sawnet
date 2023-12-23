using System.Linq.Expressions;
using Sawnet.Core.Specifications;

namespace Sawnet.Core.Tests.Specifications;

public class SpecificationTest
{
    private const string Value = "Value 1";
    private const string AnotherValue = "Value 2";

    [Fact]
    public void IsSatisfiedBy_Should_Return_True_If_Satisfy_Condition()
    {
        var specification = new TestSpecification();

        var satisfy = specification.IsSatisfiedBy(Value);

        satisfy.Should().BeTrue();
    }

    [Fact]
    public void IsSatisfiedBy_Should_Return_False_If_Not_Satisfy_Condition()
    {
        var specification = new TestSpecification();

        var satisfy = specification.IsSatisfiedBy(AnotherValue);

        satisfy.Should().BeFalse();
    }

    private class TestSpecification : Specification<string>
    {
        public override Expression<Func<string, bool>> ToExpression()
        {
            return _ => _ == Value;
        }
    }
}