using System;
using CQRS.Meetup.Write.Commands;
using CQRS.Meetup.Write.CommandsHandler;
using Microsoft.Extensions.DependencyInjection;

namespace CQRS.Meetup.Infra
{
    public sealed class CommandProcessor
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandProcessor(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void Dispatch(ICommand command)
        {
            Type type = typeof(ICommandHandler<>);
            Type[] typeArgs = { command.GetType() };
            Type handlerType = type.MakeGenericType(typeArgs);
            using (var scope = _serviceProvider.CreateScope())
            {
                dynamic handler = scope.ServiceProvider.GetService(handlerType);
                handler.Handle((dynamic)command);
            }
        }
    }
}
