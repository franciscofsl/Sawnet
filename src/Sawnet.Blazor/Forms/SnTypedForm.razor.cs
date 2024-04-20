using Sawnet.Blazor.Forms.Configurators;

namespace Sawnet.Blazor.Forms;

public partial class SnTypedForm<TItem> where TItem : class
{
    [Parameter]
    public TItem Item { get; set; } = Activator.CreateInstance<TItem>();
    
    [Parameter] public FormConfiguration<TItem> Configuration { get; set; }
}