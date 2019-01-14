
using CQRS.Meetup.Domain.Commands;

namespace CQRS.Meetup.Domain.CommandsHandler
{
    public abstract class CommandHandlerBase<TCommand> : IHandleCommands<TCommand> where TCommand : ICommand
    {
        private ICommandHandlingContext<TCommand> _context;

        public abstract void Handle(TCommand command);

        void IHandleCommands<TCommand>.Handle(ICommandHandlingContext<TCommand> handlingContext)
        {
            _context = handlingContext;
            Handle(handlingContext.Command);
        }
    }
}
