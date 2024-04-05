using Syncfusion.Blazor.Grids;

namespace Sawnet.Blazor.Grid.Columns;

public abstract class ColumnSetup
{
    public string PropertyName { get; set; }

    public string DisplayName { get; set; }
    public abstract ColumnType Type { get; }
    public TextAlign TextAlign { get; set; } = TextAlign.Left;
    public string Width { get; set; } = "100px";
    public string MinWidth { get; set; } = "100px";
    public bool Freeze { get; set; }
}