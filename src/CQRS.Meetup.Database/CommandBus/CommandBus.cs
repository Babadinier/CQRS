using CQRS.Meetup.Domain.Commands;
using System;
using System.Collections.Generic;

namespace CQRS.Meetup.Data.CommandBus
{
    public class CommandBus : ICommandSender
    {
        private readonly Dictionary<Type, List<Action<ICommand>>> _routes = new Dictionary<Type, List<Action<ICommand>>>();

        public void RegisterHandler<T>(Action<T> handler) where T : ICommand
        {
            List<Action<ICommand>> handlers;

            if (!_routes.TryGetValue(typeof(T), out handlers))
            {
                handlers = new List<Action<ICommand>>();
                _routes.Add(typeof(T), handlers);
            }

            handlers.Add((x => handler((T)x)));
        }

        public void Send<T>(T command) where T : ICommand
        {
            List<Action<ICommand>> handlers;

            if (_routes.TryGetValue(typeof(T), out handlers))
            {
                if (handlers.Count != 1) throw new InvalidOperationException("cannot send to more than one handler");
                handlers[0](command);
            }
            else
            {
                throw new InvalidOperationException("no handler registered");
            }
        }
    }
}
