using System.Diagnostics.CodeAnalysis;

namespace Raftel.Blazor.Services.LocalStorage;

[ExcludeFromCodeCoverage]
public class ChangingEventArgs : ChangedEventArgs
{
    public bool Cancel { get; set; }
}