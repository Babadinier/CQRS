using System.Collections.Generic;
using System.Linq;
using CQRS.Meetup.Data.Models;
using CQRS.Meetup.Data.Utils;
using CQRS.Meetup.Domain.ReadModel.Products;

namespace CQRS.Meetup.Data.Repositories.Products
{
    //todo : entityProduct in database, how to use it ? Need to use one model for read and write different than product ? 
    public class ProvideProductRepository
    {
        private readonly IRepository<Product> _productRepository;

        public ProvideProductRepository()
        {
            _productRepository = new Repository<Product>();
        }

        public IEnumerable<ProductDto> GetAll()
        {
            var products = _productRepository.GetAll().Result;
            return products.OrderBy(x => x.Name).Select(x => x.ToDto());
        }
    }
}
