namespace Sawnet.Blazor.Services;

public abstract class EventNotifier
{
    public Func<Task> Notify { get; set; }

    public async Task Update()
    {
        if (Notify != null)
        {
            await Notify();
        }
    }
}