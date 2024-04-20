using Sawnet.Blazor.Forms.Configurators;

namespace Sawnet.Blazor.Forms;

public partial class SnTypedModalForm<TItem>
{
    private SnTypedForm<TItem> _typedForm;
    private SnModalForm _modalForm;

    [Parameter] public string Title { get; set; }

    [Parameter] public EventCallback<TItem> OnSaveClicked { get; set; }

    [Parameter] public string Width { get; set; } = "auto";

    [Parameter] public string Height { get; set; } = "auto";

    [Parameter] public FormConfiguration<TItem> Configuration { get; set; }

    public Task ShowAsync()
    {
        return _modalForm.ShowAsync();
    }

    private Task Close()
    {
        return _modalForm.CloseAsync();
    }

    private async Task SaveAsync()
    {
        if (OnSaveClicked.HasDelegate)
        {
            await OnSaveClicked.InvokeAsync(_typedForm.Item);
        }
    }
}