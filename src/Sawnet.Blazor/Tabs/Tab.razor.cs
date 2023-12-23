namespace Sawnet.Blazor.Tabs;

public partial class Tab
{
    [Parameter] public string Title { get; set; }

    [Parameter] public RenderFragment TabContent { get; set; }
}