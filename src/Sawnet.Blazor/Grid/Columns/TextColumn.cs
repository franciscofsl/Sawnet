namespace Sawnet.Blazor.Grid.Columns;

public class TextColumn : ColumnSetup
{
    public override ColumnType Type => ColumnType.Text;

    public bool Visible { get; set; } = true;
}