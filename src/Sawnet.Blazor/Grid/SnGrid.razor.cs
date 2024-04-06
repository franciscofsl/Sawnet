using System.Collections.ObjectModel;
using Syncfusion.Blazor.Grids;

namespace Sawnet.Blazor.Grid;

public partial class SnGrid<TItem, TSetup> : SnComponentBase
    where TItem : class
    where TSetup : GridSetup<TItem>
{
    private GridPageSettings _pageSettings;
    private SfGrid<TItem> _grid;

    public ObservableCollection<TItem> Data { get; private set; }

    [Parameter] public string Title { get; set; }

    [Parameter] public GridSetup<TItem> Setup { get; set; }

    [Parameter] public Func<Task<GridData<TItem>>> GetDataFn { get; set; }

    [Parameter] public GridSelectionType SelectionMode { get; set; } = GridSelectionType.Single;

    [Parameter] public EventCallback OnCreateClicked { get; set; }

    [Parameter] public EventCallback<TItem> OnEditClicked { get; set; }

    [Parameter] public EventCallback<TItem> OnDeleteClicked { get; set; }

    [Parameter] public EventCallback OnSelectionChanged { get; set; }

    public TItem SelectedItem => _grid?.SelectedRecords.FirstOrDefault();

    public async Task Refresh()
    {
        await GetData();
        StateHasChanged();
    }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        if (Data is null)
        {
            await Refresh();
        }
    }

    private async Task OnSelectionChangedAsync()
    {
        if (OnSelectionChanged.HasDelegate)
        {
            await OnSelectionChanged.InvokeAsync();
        }
    }

    private SelectionType GetSelectionType()
    {
        return SelectionMode switch
        {
            GridSelectionType.Multiple => SelectionType.Multiple,
            _ => SelectionType.Single
        };
    }

    private async Task GetData()
    {
        var resultTask = GetDataFn.Invoke();
        var items = await resultTask;
        Data = new ObservableCollection<TItem>(items.Items);
        StateHasChanged();
    }

    private async Task OnCreateClickedAsync()
    {
        if (OnCreateClicked.HasDelegate)
        {
            await OnCreateClicked.InvokeAsync();
        }
    }

    private async Task OnEditClickedAsync(TItem item = null)
    {
        if (OnEditClicked.HasDelegate)
        {
            item ??= SelectedItem;
            await OnEditClicked.InvokeAsync(item);
        }
    }

    private async Task OnDeleteClickedAsync()
    {
        if (OnDeleteClicked.HasDelegate)
        {
            await OnDeleteClicked.InvokeAsync(SelectedItem);
        }
    }
}