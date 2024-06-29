namespace Raftel.Application.Cqrs.Queries;

public interface IQueryDispatcher
{
    Task<TQueryResult> Dispatch<TQueryResult>(IQuery<TQueryResult> command);
}