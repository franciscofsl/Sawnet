namespace Sawnet.Blazor.Forms;

public partial class SnTypedForm<TItem, TSetup>
{
    [Parameter] public TSetup Setup { get; set; }

    [Parameter]
    public TItem Item { get; set; } = Activator.CreateInstance<TItem>();
}