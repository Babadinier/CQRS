using System.Collections.Generic;
using CQRS.Meetup.Data.Repositories.Products;
using CQRS.Meetup.Domain.ReadModel.Products;

namespace CQRS.Meetup.Data.Adapters
{
    //todo : need to use interface (one for read, one for write for repository) ?
    public class ProductsAdapter : IProvideProduct
    {
        private readonly ProvideProductRepository _provideProductRepository;

        public ProductsAdapter()
        {
            _provideProductRepository = new ProvideProductRepository();
        }

        public IEnumerable<ProductDto> RetrieveProducts()
        {
            return _provideProductRepository.GetAll();
        }
    }
}
