using System;
using System.Reflection;
using CQRS.Meetup.Read.QueriesHandler;
using CQRS.Meetup.Read.ReadModel;
using Microsoft.Extensions.DependencyInjection;

namespace CQRS.Meetup.Infra
{
    public sealed class QueryProcessor
    {
        private static readonly MethodInfo OpenDispatchMethod = typeof(QueryProcessor).GetTypeInfo().GetDeclaredMethod(nameof(DispatchInternal));
        private readonly IServiceProvider _serviceProvider;

        public QueryProcessor(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        
        public T Dispatch<T>(IQuery<T> query)
        {
            var dispatchMethod = OpenDispatchMethod.MakeGenericMethod(query.GetType(), typeof(T));
            return (T)dispatchMethod.Invoke(this, new object[] {query});
        }

        private TResult DispatchInternal<TQuery, TResult>(TQuery query)
            where TQuery : IQuery<TResult>
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var handler = scope.ServiceProvider.GetService< IQueryHandler <TQuery,TResult>> ();
                return handler.Handle(query);
            }
        }
    }
}
