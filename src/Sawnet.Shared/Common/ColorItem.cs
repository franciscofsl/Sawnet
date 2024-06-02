using System.Runtime.Serialization;

namespace Sawnet.Shared.Common;

[DataContract]
public record ColorItem
{
    public ColorItem()
    {
    }

    public ColorItem(string value, string color)
    {
        Value = value;
        Color = color;
    }

    [DataMember(Order = 1)] public string Value { get; set; }

    [DataMember(Order = 2)] public string Color { get; set; }
}