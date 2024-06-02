using Sawnet.Core.Specifications;

namespace Sawnet.Core.Tests.Specifications;

public class FilterTest
{
    private class Item
    {
        public string Code { get; set; }
    }

    [Fact]
    public void Should_Satisfy_Item_Filter_If_Condition_True()
    {
        var item = new Item
        {
            Code = "New Code"
        };

        var criteria = Filter<Item>
            .Create()
            .WhereIf(true, _ => _.Code == item.Code);

        criteria.IsSatisfiedBy(item).Should().BeTrue();
    }

    [Fact]
    public void Should_Satisfy_Item_Filter_If_Condition_False()
    {
        var item = new Item
        {
            Code = "New Code"
        };

        var criteria = Filter<Item>
            .Create()
            .WhereIf(false, _ => _.Code == item.Code);

        criteria.IsSatisfiedBy(item).Should().BeTrue();
    }

    [Fact]
    public void Should_Satisfy_Or_Filter()
    {
        var item = new Item
        {
            Code = "New Code"
        };

        var criteria = Filter<Item>
            .Create()
            .OrIf(true, _ => _.Code.Contains("New"))
            .OrIf(true, _ => _.Code.Contains("Code"));

        criteria.IsSatisfiedBy(item).Should().BeTrue();
    }

    [Fact]
    public void Should_Not_Satisfy_Item_Filter_With_Not()
    {
        var item = new Item
        {
            Code = "New Code"
        };

        var criteria = Filter<Item>
            .Create()
            .Not(_ => _.Code == item.Code);

        criteria.IsSatisfiedBy(item).Should().BeFalse();
    }

    [Fact]
    public void Should_Satisfy_Item_Filter_With_NotIf_True()
    {
        var item = new Item
        {
            Code = "New Code"
        };

        var criteria = Filter<Item>
            .Create()
            .NotIf(true, _ => _.Code == item.Code);

        criteria.IsSatisfiedBy(item).Should().BeFalse();
    }

    [Fact]
    public void Should_Satisfy_Item_Filter_With_NotIf_False()
    {
        var item = new Item
        {
            Code = "New Code"
        };

        var criteria = Filter<Item>
            .Create()
            .NotIf(false, _ => _.Code == item.Code);

        criteria.IsSatisfiedBy(item).Should().BeTrue();
    }

    [Fact]
    public void Should_Combine_Filters_With_And_Operator()
    {
        var item = new Item
        {
            Code = "New Code"
        };

        var combinedFilter = Filter<Item>
            .Create()
            .Where(_ => _.Code.Contains("New"))
            .Combine(Filter<Item>.Create().Where(_ => _.Code.Contains("Code")));

        combinedFilter.IsSatisfiedBy(item).Should().BeTrue();
    }

    [Fact]
    public void Should_Combine_Filters_With_Or_Operator()
    {
        var item = new Item
        {
            Code = "New Code"
        };

        var filter = Filter<Item>.Create()
            .Where(_ => _.Code.Contains("New"))
            .Or(_ => _.Code.Contains("Code"));

        filter.IsSatisfiedBy(item).Should().BeTrue();
    }

    [Fact]
    public void Should_Not_Satisfy_Filter_With_False_And_Condition()
    {
        var item = new Item
        {
            Code = "New Code"
        };

        var combinedFilter = Filter<Item>.Create()
            .Where(_ => _.Code.Contains("New"))
            .And(_ => _.Code.EndsWith("Foo"));

        combinedFilter.IsSatisfiedBy(item).Should().BeFalse();
    }

    [Fact]
    public void Should_Satisfy_Filter_With_True_And_Condition()
    {
        var item = new Item
        {
            Code = "New Code"
        };

        var combinedFilter = Filter<Item>.Create()
            .Where(_ => _.Code.Contains("New"))
            .And(_ => _.Code.EndsWith("Code"));

        combinedFilter.IsSatisfiedBy(item).Should().BeTrue();
    }

    [Fact]
    public void Should_Return_Same_Filter_If_And_Condition_False()
    {
        var item = new Item
        {
            Code = "New Code"
        };

        var combinedFilter = Filter<Item>.Create()
            .Where(_ => _.Code.Contains("New"))
            .And(_ => _.Code.EndsWith("Code"))
            .AndIf(false, _ => _.Code.StartsWith("New"));

        combinedFilter.IsSatisfiedBy(item).Should().BeTrue();
    }
}