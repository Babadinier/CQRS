using System.Collections.Generic;
using System.Threading.Tasks;

namespace CQRS.Meetup.Data.Repositories
{
    public interface IRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAll();
        void Insert(TEntity entity);
        void Save();
    }
}
