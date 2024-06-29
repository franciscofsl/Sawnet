namespace Raftel.Blazor.Services;

public abstract class EventNotifier
{
    public Func<Task> Notify { get; set; }

    public async Task Update()
    {
        if (Notify != null) await Notify();
    }
}

public abstract class EventNotifier<TItem>
{
    public Func<TItem, Task> Notify { get; set; }

    public async Task Update(TItem item)
    {
        if (Notify != null) await Notify(item);
    }
}