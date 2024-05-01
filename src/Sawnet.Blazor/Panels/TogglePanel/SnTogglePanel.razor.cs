namespace Sawnet.Blazor.Panels.TogglePanel;

public partial class SnTogglePanel
{
    private bool _collapsed = true;

    [Parameter] public string Text { get; set; }

    [Parameter] public string Icon { get; set; }

    [Parameter] public RenderFragment Content { get; set; }

    protected override async Task OnInitializedAsync()
    {
        _collapsed = await LocalStorage.GetItemAsync<bool>(StateStoreKey);
    }

    private async Task TogglePanel()
    {
        _collapsed = !_collapsed;
        await LocalStorage.SetItemAsync(StateStoreKey, _collapsed);
    }

    private string PanelDisplayStyle()
    {
        return _collapsed ? "display: none;" : "display: block;";
    }
}