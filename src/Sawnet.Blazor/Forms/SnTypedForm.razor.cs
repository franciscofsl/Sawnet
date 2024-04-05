namespace Sawnet.Blazor.Forms;

public partial class SnTypedForm<TItem, TSetup>
{
    [Parameter] public TSetup Setup { get; set; }

    public TItem Item { get; set; } = Activator.CreateInstance<TItem>();
}