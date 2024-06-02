using System.Collections.ObjectModel;
using Sawnet.Blazor.Forms.Configurators;
using Sawnet.Blazor.Forms.Groups;
using Sawnet.Blazor.Shared.Grpc.Filters;
using Syncfusion.Blazor.Grids;

namespace Sawnet.Blazor.Grid;

public partial class SnGrid<TItem, TSetup, TFilter> : SnComponentBase
    where TItem : class
    where TSetup : GridSetup<TItem>
    where TFilter : GridFilter
{
    private GridPageSettings _pageSettings;
    private SfGrid<TItem> _grid;

    public ObservableCollection<TItem> Data { get; private set; }

    [Parameter] public string Title { get; set; }

    [Parameter] public GridSetup<TItem> Setup { get; set; }

    [Parameter] public Func<TFilter, Task<GridData<TItem>>> GetDataFn { get; set; }

    [Parameter] public GridSelectionType SelectionMode { get; set; } = GridSelectionType.Single;

    [Parameter] public EventCallback OnCreateClicked { get; set; }

    [Parameter] public EventCallback<TItem> OnEditClicked { get; set; }

    [Parameter] public EventCallback<TItem> OnDeleteClicked { get; set; }

    [Parameter] public EventCallback OnSelectionChanged { get; set; }

    [Parameter] public FieldConfigurator<TFilter> FilterConfiguration { get; set; }

    [Parameter] public RenderFragment Insight { get; set; }

    private bool _isRightPanelVisible = false;
    private bool _isLeftPanelVisible = false;
    private string RightVisibleCssClass => _isRightPanelVisible ? "visible" : string.Empty;
    private string LeftVisibleCssClass => _isLeftPanelVisible ? "visible" : string.Empty;
    public TFilter Filter { get; } = Activator.CreateInstance<TFilter>();

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

    private void ToggleRightPanel()
    {
        _isRightPanelVisible = !_isRightPanelVisible;
    }

    private void ToggleLeftPanel()
    {
        _isLeftPanelVisible = !_isLeftPanelVisible;
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
        var resultTask = GetDataFn.Invoke(Filter);
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

    private FormConfiguration<TFilter> GetFilterConfiguration()
    {
        var defaultGroups = new List<FormGroup<TFilter>>()
        {
            new()
            {
                Columns = FormColumns.One,
                Fields = FilterConfiguration.Fields
            }
        };
        return new FormConfiguration<TFilter>(defaultGroups);
    }
}