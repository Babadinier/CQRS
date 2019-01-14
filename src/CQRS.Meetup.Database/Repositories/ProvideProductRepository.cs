using System.Collections.Generic;
using CQRS.Meetup.Domain.ReadModel;
using CQRS.Meetup.Domain.WriteModel;
using System.Linq;

namespace CQRS.Meetup.Data.Repositories
{
    //todo : entityProduct in database, how to use it ? Need to use one model for read and write different than product ? 
    public class ProvideProductRepository
    {
        private IRepository<Product> _productRepository;

        public ProvideProductRepository()
        {
            _productRepository = new Repository<Product>();
        }

        public IEnumerable<ProductDto> GetAll()
        {
            var products = _productRepository.GetAll().Result;
            return products.Select(x => x.ToDto());
        }
    }

    public static class Helper
    {
        public static ProductDto ToDto(this Product product)
        {
            return new ProductDto()
            {
                Id = product.Id,
                Name = product.Name,
                Quantity = product.Quantity
            };
        }
    }
}
