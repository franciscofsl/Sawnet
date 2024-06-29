using System.Text.Json;

namespace Raftel.Blazor.Services.LocalStorage.StorageOptions;

public class LocalStorageOptions
{
    public JsonSerializerOptions JsonSerializerOptions { get; set; } = new();
}