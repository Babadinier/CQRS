using CQRS.Meetup.Domain.Commands;

namespace CQRS.Meetup.Domain.CommandsHandler
{
    public interface IHandleCommands<in TCommand> where TCommand : ICommand
    {
        void Handle(ICommandHandlingContext<TCommand> handlingContext);
    }
}
