using Radzen;

namespace Sawnet.Blazor.Grid;

public abstract class ColumnSetup
{
    public string PropertyName { get; set; }

    public string DisplayName { get; set; }
    public abstract ColumnType Type { get; }
    public abstract TextAlign TextAlign { get; }
    public bool Frozen { get; }
    public string Width { get; set; } = "100px";
    public string MinWidth { get; set; } = "100px";
}