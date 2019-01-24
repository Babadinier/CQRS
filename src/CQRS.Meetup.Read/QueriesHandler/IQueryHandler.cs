using CQRS.Meetup.Read.ReadModel;

namespace CQRS.Meetup.Read.QueriesHandler
{
    public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        TResult Handle(TQuery query);
    }
}