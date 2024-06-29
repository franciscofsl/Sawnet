namespace Raftel.Blazor.Panels.TabPanel;

public partial class SnTabItem
{
    [Parameter] public RenderFragment Content { get; set; }
    
    [Parameter] public string Title { get; set; }
    
    [Parameter] public string Icon { get; set; }
}