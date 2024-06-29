using Raftel.Blazor.Grid.Columns.Types;

namespace Raftel.Blazor.Grid.Columns.Templates;

public partial class SnTextColumnTemplate<TItem>
{
    [Parameter] public TextColumn Column { get; set; }
    
    [Parameter] public TItem Item { get; set; }
}