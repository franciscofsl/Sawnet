namespace Sawnet.Application.Cqrs.Queries;

public class QueryDispatcher : IQueryDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public QueryDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task<TQueryResult> Dispatch<TQueryResult>(IQuery<TQueryResult> command)
    {
        var type = typeof(IQueryHandler<,>).MakeGenericType(command.GetType(), typeof(TQueryResult));
        dynamic handler = _serviceProvider.GetService(type);
        return await handler.Handle((dynamic)command);
    }
}