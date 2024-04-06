using Syncfusion.Blazor.Navigations;

namespace Sawnet.Blazor.Toolbar;

public partial class SnToolbarAction
{
    [Parameter] public string TooltipText { get; set; }
    [Parameter] public string Text { get; set; }
    [Parameter] public string Icon { get; set; }
    [Parameter] public bool Disabled { get; set; }
    [Parameter] public EventCallback OnClick { get; set; }
    [Parameter] public ToolbarDisplayMode DisplayMode { get; set; }
    [Parameter] public ToolbarActionAlign Align { get; set; }

    private Task ClickAsync()
    {
        if (OnClick.HasDelegate)
        {
            return OnClick.InvokeAsync();
        }

        return Task.CompletedTask;
    }
}

public enum ToolbarDisplayMode
{
    Both,
    Overflow,
    Toolbar
}

internal static class ToolbarDisplayParser
{
    public static DisplayMode ToSyncfusionValue(this ToolbarDisplayMode displayMode)
    {
        return displayMode switch
        {
            ToolbarDisplayMode.Both => DisplayMode.Both,
            ToolbarDisplayMode.Overflow => DisplayMode.Overflow,
            ToolbarDisplayMode.Toolbar => DisplayMode.Toolbar,
            _ => DisplayMode.Both
        };
    }
}

public enum ToolbarActionAlign
{
    Left,
    Center,
    Right,
}

internal static class ToolbarActionAlignParser
{
    public static ItemAlign ToSyncfusionValue(this ToolbarActionAlign displayMode)
    {
        return displayMode switch
        {
            ToolbarActionAlign.Left => ItemAlign.Left,
            ToolbarActionAlign.Center => ItemAlign.Center,
            ToolbarActionAlign.Right => ItemAlign.Right,
            _ => ItemAlign.Left
        };
    }
}