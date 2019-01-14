using CQRS.Meetup.Domain.Commands;

namespace CQRS.Meetup.Data.CommandBus
{
    public interface ICommandSender
    {
        void Send<T>(T command) where T : ICommand;
    }
}