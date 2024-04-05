namespace Sawnet.Blazor.Panels.TogglePanel;

public partial class SnTogglePanel
{
    private bool _collapsed = true;
    
    [Parameter] public string Text { get; set; }
    [Parameter] public string Icon { get; set; }
    
    [Parameter] public RenderFragment Content { get; set; }

    private void TogglePanel()
    {
        _collapsed = !_collapsed;
    }

    private string PanelDisplayStyle()
    {
        return _collapsed ? "display: none;" : "display: block;";
    }
}