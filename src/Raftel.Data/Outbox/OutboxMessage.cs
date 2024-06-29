using Newtonsoft.Json;
using Raftel.Core.Events;

namespace Raftel.Data.Outbox;

public sealed class OutboxMessage
{
    public Guid Id { get; init; }

    public string Type { get; init; }

    public string Content { get; init; }

    public DateTime OccurredOn { get; init; }

    public DateTime? ProcessedOn { get; set; }

    public IDomainEvent ToDomainEvent()
    {
        return JsonConvert
            .DeserializeObject<IDomainEvent>(
                Content,
                new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                });
    }
}