using CQRS.Meetup.Domain.Commands;

namespace CQRS.Meetup.Domain.CommandsHandler
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        void Handle(TCommand handlingContext);
    }
}
