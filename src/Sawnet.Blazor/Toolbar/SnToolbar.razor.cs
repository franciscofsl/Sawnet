namespace Sawnet.Blazor.Toolbar;

public partial class SnToolbar
{
    [Parameter] public string Title { get; set; }

    [Parameter] public RenderFragment Actions { get; set; }
}