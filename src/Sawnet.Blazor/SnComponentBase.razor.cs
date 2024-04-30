using Sawnet.Blazor.Services.LocalStorage;
using Sawnet.Blazor.Toast;

namespace Sawnet.Blazor;

public abstract partial class SnComponentBase : ComponentBase, IDisposable
{
    [Inject] protected ILocalStorageService LocalStorage { get; set; }

    [Parameter] public string StateStoreKey { get; set; }

    [Inject] protected ToastService Toast { get; set; }

    public virtual void Dispose()
    {
    }
}