using CQRS.Meetup.Domain.WriteModel;

namespace CQRS.Meetup.Data.Repositories
{
    //todo: need to dispatch repository (one for create, one for read) ?
    public class ProductRepository : ICreateProduct
    {
        private IRepository<Product> _productRepository;

        public ProductRepository()
        {
            _productRepository = new Repository<Product>();
        }

        public void Create(Product product)
        {
            if(product != null)
            {
                _productRepository.Insert(product);
                _productRepository.Save();
            }
        }
    }
}
