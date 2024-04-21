using Syncfusion.Blazor.Popups;

namespace Sawnet.Blazor.Forms;

public partial class SnModalForm
{
    private SfDialog _dialog;

    [Parameter] public string PrimaryButtonText { get; set; } = "Common.Accept";

    [Parameter] public string PrimaryButtonIcon { get; set; }

    [Parameter] public string SecondaryButtonText { get; set; } = "Common.Cancel";

    [Parameter] public string SecondaryButtonIcon { get; set; }

    [Parameter] public string Title { get; set; }

    [Parameter] public string Width { get; set; }

    [Parameter] public string Height { get; set; }

    [Parameter] public RenderFragment Body { get; set; }

    [Parameter] public EventCallback OnPrimaryButtonClicked { get; set; }

    [Parameter] public EventCallback OnSecondaryButtonClicked { get; set; }

    [Parameter] public bool ShowCloseButton { get; set; } = true;
    
    [Parameter] public RenderFragment<string> Header { get; set; }
    
    [Parameter] public bool HasFooter { get; set; }

    public Task CloseAsync()
    {
        return _dialog.HideAsync();
    }

    public Task ShowAsync()
    {
        return _dialog.ShowAsync();
    }

    private Task OnPrimaryButtonClickedAsync()
    {
        return OnPrimaryButtonClicked.HasDelegate
            ? OnPrimaryButtonClicked.InvokeAsync()
            : Task.CompletedTask;
    }

    private async Task OnSecondaryButtonClickedAsync()
    {
        if (OnSecondaryButtonClicked.HasDelegate)
        {
            await OnPrimaryButtonClicked.InvokeAsync();
        }

        await CloseAsync();
    }
}