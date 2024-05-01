using System.Text.Json;
using Microsoft.Extensions.Options;
using Sawnet.Blazor.Services.LocalStorage.StorageOptions;

namespace Sawnet.Blazor.Services.LocalStorage.Serialization;

internal class SystemTextJsonSerializer : IJsonSerializer
{
    private readonly JsonSerializerOptions _options;

    public SystemTextJsonSerializer(IOptions<LocalStorageOptions> options)
    {
        _options = options.Value.JsonSerializerOptions;
    }

    public SystemTextJsonSerializer(LocalStorageOptions localStorageOptions)
    {
        _options = localStorageOptions.JsonSerializerOptions;
    }

    public T Deserialize<T>(string data)
    {
        return JsonSerializer.Deserialize<T>(data, _options);
    }

    public string Serialize<T>(T data)
    {
        return JsonSerializer.Serialize(data, _options);
    }
}