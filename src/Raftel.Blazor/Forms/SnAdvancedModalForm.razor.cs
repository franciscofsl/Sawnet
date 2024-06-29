using System.Text.Json;
using Raftel.Blazor.Forms.Configurators;
using Raftel.Blazor.Toast;
using Syncfusion.Blazor.Popups;

namespace Raftel.Blazor.Forms;

public partial class SnAdvancedModalForm<TItem> where TItem : class
{
    private bool _unsavedChanges;
    private string _originalItem;
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

    [Parameter] public RenderFragment<TItem> Content { get; set; }

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
    
    public void CheckPendingChanges()
    {
        var currentItemAsJson = JsonSerializer.Serialize(Item);
        _unsavedChanges = currentItemAsJson != _originalItem;
        StateHasChanged();
    }

    private async Task SaveAsync()
    {
        if (OnSaveClicked.HasDelegate)
        {
            await OnSaveClicked.InvokeAsync(Item);
            Toast.Success(new ToastMessage("Common.ElementSaved", "Common.ElementSavedSuccess"));
            _originalItem = JsonSerializer.Serialize(Item);
            CheckPendingChanges();
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
        var item = await OnGetItemFn(id);
        _originalItem = JsonSerializer.Serialize(item);
        return item;
    }

    private void ToggleRightPanel()
    {
        _isRightPanelVisible = !_isRightPanelVisible;
    }

    private Task OnAnyPropertyChanged()
    {
        CheckPendingChanges();
        return Task.CompletedTask;
    }
}