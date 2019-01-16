using CQRS.Meetup.Domain.Commands;
using CQRS.Meetup.Domain.CommandsHandler;
using CQRS.Meetup.Domain.ReadModel;
using System;
using CQRS.Meetup.Domain.QueriesHandler;

namespace CQRS.Meetup.Domain
{
    public sealed class Messages
    {
        private readonly IServiceProvider _serviceProvider;

        public Messages(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void Dispatch(ICommand command)
        {
            Type type = typeof(ICommandHandler<>);
            Type[] typeArgs = { command.GetType() };
            Type handlerType = type.MakeGenericType(typeArgs);

            dynamic handler = _serviceProvider.GetService(handlerType);
            handler.Handle((dynamic)command);
        }

        public T Dispatch<T>(IQuery<T> query)
        {
            Type type = typeof(IQueryHandler<,>);
            Type[] typeArgs = { query.GetType(), typeof(T) };
            Type handlerType = type.MakeGenericType(typeArgs);

            dynamic handler = _serviceProvider.GetService(handlerType);
            T result = handler.Handle((dynamic)query);

            return result;
        }
    }
}
