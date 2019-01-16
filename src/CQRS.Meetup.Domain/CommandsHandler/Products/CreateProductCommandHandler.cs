using CQRS.Meetup.Domain.Commands.Products;
using CQRS.Meetup.Domain.WriteModel.Products;

namespace CQRS.Meetup.Domain.CommandsHandler.Products
{
    //todo gub : "CQRS in practice" on pluralsight said that CommandHandler need to go to Application Services (Web). Best place ? 
    //todo gub : "CQRS in practice regroup commandHandler with command with internal sealed class. This allows to delete command with commandHandler. Add it in README ?
    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand>
    {
        private readonly ICreateProduct _createProduct;

        public CreateProductCommandHandler(ICreateProduct createProduct)
        {
            _createProduct = createProduct;
        }

        public void Handle(CreateProductCommand command)
        {
            _createProduct.Create(command);
        }
    }
}
