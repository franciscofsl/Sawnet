namespace Raftel.Blazor.Toast;

public class ToastType
{
    private ToastType(string cssClass, string icon)
    {
        CssClass = cssClass;
        Icon = icon;
    }

    public string CssClass { get; }

    public string Icon { get; }

    public static ToastType Success => new("e-toast-success", "fas fa-check");
}