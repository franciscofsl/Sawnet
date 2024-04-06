namespace Sawnet.Blazor.Grid.Columns.Types;

public class DateColumn : ColumnSetup
{
    public override ColumnType Type => ColumnType.DateOnly;

    public DateFormat Format { get; set; }
}

public enum DateFormat
{
    DateOnly,
    DateAndHour
}