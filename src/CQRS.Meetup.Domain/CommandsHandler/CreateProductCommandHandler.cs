using CQRS.Meetup.Domain.Commands;
using CQRS.Meetup.Domain.WriteModel;
using System;

namespace CQRS.Meetup.Domain.CommandsHandler
{
    public class CreateProductCommandHandler : CommandHandlerBase<CreateProductCommand>
    {
        private readonly ICreateProduct _createProduct;

        public CreateProductCommandHandler(ICreateProduct createProduct)
        {
            _createProduct = createProduct;
        }

        public override void Handle(CreateProductCommand command)
        {
            var product = new Product(Guid.NewGuid(), command.Name, command.Quantity);
            _createProduct.Create(product);
        }
    }
}
