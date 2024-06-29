namespace Raftel.Blazor.Panels.InfoPanel;

public partial class SnInfoPanel
{
    [Parameter] public string Title { get; set; }
    
    [Parameter] public string Icon { get; set; }
    
    [Parameter] public RenderFragment Items { get; set; }
}