using System.Diagnostics.CodeAnalysis;

namespace Raftel.Blazor.Services.LocalStorage;

[ExcludeFromCodeCoverage]
public class ChangedEventArgs
{
    public string Key { get; set; } = null!;
    public object OldValue { get; set; }
    public object NewValue { get; set; }
}