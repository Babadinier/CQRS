using CQRS.Meetup.Domain.ReadModel;

namespace CQRS.Meetup.Domain.QueriesHandler
{
    public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        TResult Handle(TQuery query);
    }
}