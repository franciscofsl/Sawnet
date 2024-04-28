using Sawnet.Blazor.Services.LocalStorage;

namespace Sawnet.Blazor;

public abstract class SnComponentBase : ComponentBase, IDisposable
{
    [Inject] protected ILocalStorageService LocalStorage { get; set; }

    [Parameter] public string StateStoreKey { get; set; }

    public virtual void Dispose()
    {
    }
}