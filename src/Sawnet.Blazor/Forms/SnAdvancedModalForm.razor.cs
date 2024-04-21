using Sawnet.Blazor.Forms.Configurators;
using Syncfusion.Blazor.Popups;

namespace Sawnet.Blazor.Forms;

public partial class SnAdvancedModalForm<TItem> where TItem : class
{
    private SnTypedForm<TItem> _typedForm;
    private bool _isRightPanelVisible = false;
    private SfDialog _dialog;

    [Parameter] public FormConfiguration<TItem> Configuration { get; set; }

    [Parameter] public string Title { get; set; }

    [Parameter] public EventCallback<TItem> OnSaveClicked { get; set; }

    [Parameter] public Func<Guid, Task<TItem>> OnGetItemFn { get; set; }

    [Parameter] public EventCallback<TItem> OnDeleteClicked { get; set; }
    
    [Parameter] public RenderFragment Insight { get; set; }
    
    [Parameter] public RenderFragment<TItem> LeftToolbarItems { get; set; }
    
    [Parameter] public RenderFragment<TItem> RightToolbarItems { get; set; }

    public TItem Item { get; private set; }

    private string RightPanelClass => _isRightPanelVisible ? "visible" : string.Empty;

    public async Task ShowAsync(Guid id)
    {
        Item = await GetEntityAsync(id);
        await _dialog.ShowAsync();
    }

    public Task CloseAsync()
    {
        return _dialog.HideAsync();
    }

    private async Task SaveAsync()
    {
        if (OnSaveClicked.HasDelegate)
        {
            await OnSaveClicked.InvokeAsync(_typedForm.Item);
        }
    }

    private async Task DeleteAsync()
    {
        if (OnDeleteClicked.HasDelegate)
        {
            await OnDeleteClicked.InvokeAsync(_typedForm.Item);
            await CloseAsync();
        }
    }

    private async Task<TItem> GetEntityAsync(Guid id)
    {
        return await OnGetItemFn(id);
    }

    private void ToggleRightPanel()
    {
        _isRightPanelVisible = !_isRightPanelVisible;
    }
}