namespace Sawnet.Blazor.Menu;

public partial class AppMenu
{
    [Inject] private MenuDefinitionProvider MenuDefinitionProvider { get; set; }

    [Inject] private NavigationManager NavigationManager { get; set; }

    private Task OpenPage(string url)
    {
        NavigationManager.NavigateTo(url);
        return Task.CompletedTask;
    }
}