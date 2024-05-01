namespace Sawnet.Blazor.Toast;

public sealed class ToastService(ToastNotifier notifier)
{
    public void Success(ToastMessage message)
    {
        notifier
            .Update(new ToastOptions
            {
                Message = message,
                Type = ToastType.Success
            })
            .Forget();
    }
}