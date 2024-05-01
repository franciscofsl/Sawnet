namespace Sawnet.Blazor.Toast;

public record ToastOptions
{
    public ToastMessage Message { get; init; }
    public ToastType Type { get; init; }
}