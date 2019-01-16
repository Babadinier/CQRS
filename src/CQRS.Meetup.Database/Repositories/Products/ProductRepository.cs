using System;
using CQRS.Meetup.Data.Models;
using CQRS.Meetup.Domain.Commands.Products;
using CQRS.Meetup.Domain.WriteModel.Products;

namespace CQRS.Meetup.Data.Repositories.Products
{
    //todo: need to dispatch repository (one for create, one for read). Agree ? (ProductRepository and ProvideProductRepository)
    public class ProductRepository : ICreateProduct
    {
        private readonly IRepository<Product> _productRepository;

        public ProductRepository()
        {
            _productRepository = new Repository<Product>();
        }

        public void Create(CreateProductCommand productCommand)
        {
            if (productCommand == null) return;
            var product = new Product(Guid.NewGuid(), productCommand.Name, productCommand.Quantity);
            _productRepository.Insert(product);
            _productRepository.Save();
        }
    }
}
