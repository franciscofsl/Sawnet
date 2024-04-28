using System.Text.Json;

namespace Sawnet.Blazor.Services.LocalStorage.StorageOptions;

public class LocalStorageOptions
{
    public JsonSerializerOptions JsonSerializerOptions { get; set; } = new();
}