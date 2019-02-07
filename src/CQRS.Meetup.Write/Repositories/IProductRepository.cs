using System;
using CQRS.Meetup.Write.Models;

namespace CQRS.Meetup.Write.Repositories
{
    public interface IProductRepository
    {
        void Create(Product product);

        Product Get(Guid id);

        Product GetByName(string name);

        bool Exists(string name);
    }
}
