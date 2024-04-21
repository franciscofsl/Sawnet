namespace Sawnet.Blazor.Buttons;

public partial class SnLinkButton
{
    [Parameter]
    public string Text { get; set; }

    [Parameter]
    public string Icon { get; set; }
    
    [Parameter]
    public string IconColor { get; set; } = "#737373";

    [Parameter]
    public EventCallback OnClick { get; set; } 

    private async Task HandleClick()
    {
        if (OnClick.HasDelegate)
        {
            await OnClick.InvokeAsync(null);
        }
    }
}