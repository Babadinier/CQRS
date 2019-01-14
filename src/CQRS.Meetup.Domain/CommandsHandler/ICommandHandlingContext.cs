using CQRS.Meetup.Domain.Commands;

namespace CQRS.Meetup.Domain.CommandsHandler
{
    public interface ICommandHandlingContext<out TCommand> where TCommand : ICommand
    {
        TCommand Command { get; }
    }
}
