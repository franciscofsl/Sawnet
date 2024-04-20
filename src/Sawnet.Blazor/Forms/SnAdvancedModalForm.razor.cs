using Sawnet.Blazor.Forms.Configurators;

namespace Sawnet.Blazor.Forms;

public partial class SnAdvancedModalForm<TItem> where TItem : class
{
    private SnTypedForm<TItem> _typedForm;
    private SnModalForm _modalForm;

    [Parameter] public FormConfiguration<TItem> Configuration { get; set; }

    [Parameter] public string Title { get; set; }

    [Parameter] public EventCallback<TItem> OnSaveClicked { get; set; }

    [Parameter] public Func<Guid, Task<TItem>> OnGetItemFn { get; set; }

    [Parameter] public string Width { get; set; } = "auto";

    [Parameter] public string Height { get; set; } = "auto";

    public TItem Item { get; private set; }

    public async Task ShowAsync(Guid id)
    {
        Item = await GetEntityAsync(id);
        await _modalForm.ShowAsync();
    }

    public Task CloseAsync()
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

    private async Task<TItem> GetEntityAsync(Guid id)
    {
        return await OnGetItemFn(id);
    }
}