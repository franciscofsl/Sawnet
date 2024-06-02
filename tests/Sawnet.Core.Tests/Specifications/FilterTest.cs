using Sawnet.Core.Specifications;

namespace Sawnet.Core.Tests.Specifications;

public class FilterTest
{
    [Fact]
    public void Should_Satisfy_Item_Filter_If_Condition_True()
    {
        var item = new Item
        {
            Code = "New Code"
        };

        var criteria = Filter<Item>
            .For<Item>()
            .If(true, _ => _.Code == item.Code);

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
            .For<Item>()
            .If(false, _ => _.Code == item.Code);

        criteria.IsSatisfiedBy(item).Should().BeTrue();
    }

    private class Item
    {
        public string Code { get; set; }
    }
}