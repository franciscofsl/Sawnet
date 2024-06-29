namespace Raftel.Blazor.Forms.Fields.Types;

public sealed class DateOnlyField : FormField
{
    public override FieldType Type => FieldType.DateOnly;
    
    public DateTime? Min { get; set; }
    public DateTime? Max { get; set; }
}