using System.Collections.Generic;
using CQRS.Meetup.Data.Repositories;
using CQRS.Meetup.Domain.ReadModel;

namespace CQRS.Meetup.Data.Adapters
{
    //todo : need to use interface (one for read, one for write for repository) ?
    public class ProductsAdapter : IProvideProduct
    {
        private ProvideProductRepository _provideProductRepository;

        public ProductsAdapter()
        {
            _provideProductRepository = new ProvideProductRepository();
        }

        public IEnumerable<ProductDto> GetAllProducts()
        {
            return _provideProductRepository.GetAll();
        }
    }
}
