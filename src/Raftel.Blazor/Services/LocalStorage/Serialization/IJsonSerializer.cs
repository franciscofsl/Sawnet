namespace Raftel.Blazor.Services.LocalStorage.Serialization;

public interface IJsonSerializer
{
    string Serialize<T>(T obj);
    T Deserialize<T>(string text);
}