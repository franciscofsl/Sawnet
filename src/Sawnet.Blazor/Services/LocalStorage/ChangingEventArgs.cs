using System.Diagnostics.CodeAnalysis;

namespace Sawnet.Blazor.Services.LocalStorage;

[ExcludeFromCodeCoverage]
public class ChangingEventArgs : ChangedEventArgs
{
    public bool Cancel { get; set; }
}