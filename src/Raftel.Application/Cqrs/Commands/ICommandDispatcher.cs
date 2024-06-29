namespace Raftel.Application.Cqrs.Commands;

public interface ICommandDispatcher
{
    Task<TCommandResult> Dispatch<TCommandResult>(ICommand<TCommandResult> command);
}
