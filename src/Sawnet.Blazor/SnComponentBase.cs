using Radzen;

namespace Sawnet.Blazor;

public abstract class SnComponentBase : ComponentBase, IDisposable
{
    [Inject] protected DialogService DialogService { get; set; }

    public virtual void Dispose()
    {
        DialogService?.Dispose();
    }
}