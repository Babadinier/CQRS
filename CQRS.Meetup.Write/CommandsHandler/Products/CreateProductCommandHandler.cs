using System;
using CQRS.Meetup.Write.Commands.Products;
using CQRS.Meetup.Write.Models;
using CQRS.Meetup.Write.Repositories;

namespace CQRS.Meetup.Write.CommandsHandler.Products
{
    //todo gub : "CQRS in practice" on pluralsight said that CommandHandler need to go to Application Services (Web). Best place ? 
    //todo gub : "CQRS in practice regroup commandHandler with command with internal sealed class. This allows to delete command with commandHandler. Add it in README ?
    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Handle(CreateProductCommand command)
        {
            // todo pfe : pas de null mais exists
            var product = _productRepository.GetByName(command.Name);
            if (product == null)
            {
                product = new Product(Guid.NewGuid(), command.Name, command.Quantity);
                _productRepository.Create(product);
            }
            else
            {
                throw new InvalidOperationException($"Product {command.Name} already exists.");
            }
        }
    }
}
