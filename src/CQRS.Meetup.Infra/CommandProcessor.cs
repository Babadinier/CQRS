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

        public void Dispatch<T>(T command) where T : ICommand
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var handler = scope.ServiceProvider.GetService<ICommandHandler<T>>();
                handler.Handle(command);
            }
        }
    }
}
