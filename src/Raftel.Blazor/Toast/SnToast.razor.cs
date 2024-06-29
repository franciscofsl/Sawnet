using Syncfusion.Blazor.Notifications;

namespace Raftel.Blazor.Toast;

public partial class SnToast
{
    private SfToast _toast;

    [Inject] private ToastNotifier Notifier { get; set; }

    public override void Dispose()
    {
        base.Dispose();

        Notifier.Notify -= ShowToastAsync;
    }

    protected override Task OnInitializedAsync()
    {
        Notifier.Notify += ShowToastAsync;
        return Task.CompletedTask;
    }

    private Task ShowToastAsync(ToastOptions options)
    {
        _toast
            .ShowAsync(new ToastModel
            {
                Title = options.Message.Title,
                Content = options.Message.Message,
                Icon = options.Type.Icon,
                CssClass = options.Type.CssClass,
                ShowCloseButton = true
            })
            .Forget();
        return Task.CompletedTask;
    }
}