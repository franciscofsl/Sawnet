namespace Sawnet.Blazor.Forms.Fields.Types;

public sealed class NumericField : FormField
{
    public override FieldType Type => FieldType.Numeric;

    public NumberFormat Format { get; set; } = NumberFormat.Integer;

    public decimal? Max { get; set; }
    
    public decimal? Min { get; set; }
    
    public int NumberOfDecimals { get; set; }
}

public enum NumberFormat
{
    Integer,
    Decimal,
    Percentage
}