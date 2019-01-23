using CQRS.Meetup.Write.Commands;

namespace CQRS.Meetup.Write.CommandsHandler
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        void Handle(TCommand handlingContext);
    }
}
