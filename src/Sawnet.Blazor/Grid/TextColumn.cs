using Radzen;

namespace Sawnet.Blazor.Grid;

public class TextColumn : ColumnSetup
{
    public override ColumnType Type => ColumnType.Text;
    public override TextAlign TextAlign => TextAlign.Left;
}