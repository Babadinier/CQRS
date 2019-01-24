using System;
using CQRS.Meetup.Read.QueriesHandler;
using CQRS.Meetup.Read.ReadModel;

namespace CQRS.Meetup.Read
{
    public sealed class QueryProcessor
    {
        private readonly IServiceProvider _serviceProvider;

        public QueryProcessor(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
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
