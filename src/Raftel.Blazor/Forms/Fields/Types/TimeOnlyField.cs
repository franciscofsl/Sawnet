namespace Raftel.Blazor.Forms.Fields.Types;

public sealed class TimeOnlyField : FormField
{
    public override FieldType Type => FieldType.TimeOnly;
    
    public TimeOnly? Min { get; set; }
    
    public TimeOnly? Max { get; set; }
}