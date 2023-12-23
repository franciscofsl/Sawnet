namespace Sawnet.Application.Cqrs.Commands;

public interface ICommandHandler<in TRequest, TResult>
    where TRequest : ICommand<TResult>
{
    Task<TResult> Handle(TRequest command, CancellationToken token = default);
}
