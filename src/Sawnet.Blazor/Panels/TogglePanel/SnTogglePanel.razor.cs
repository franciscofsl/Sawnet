namespace Sawnet.Blazor.Panels.TogglePanel;

public partial class SnTogglePanel
{
    private bool collapsed = true;
    
    [Parameter] public string Text { get; set; }
    [Parameter] public string Icon { get; set; }
    
    [Parameter] public RenderFragment Content { get; set; }

    private void TogglePanel()
    {
        collapsed = !collapsed;
    }

    private string PanelDisplayStyle()
    {
        return collapsed ? "display: none;" : "display: block;";
    }
}