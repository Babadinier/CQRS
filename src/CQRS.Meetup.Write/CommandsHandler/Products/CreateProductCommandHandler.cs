using System;
using CQRS.Meetup.Write.Commands.Products;
using CQRS.Meetup.Write.Models;
using CQRS.Meetup.Write.Repositories;

namespace CQRS.Meetup.Write.CommandsHandler.Products
{
    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Handle(CreateProductCommand command)
        {
            var existingProduct = _productRepository.Exists(command.Name);
            if (!existingProduct)
            {
                var product = new Product(Guid.NewGuid(), command.Name, command.Quantity);
                _productRepository.Create(product);
            }
            else
            {
                throw new InvalidOperationException($"Product {command.Name} already exists.");
            }
        }
    }
}
