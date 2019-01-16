using CQRS.Meetup.Domain.Commands.Products;

namespace CQRS.Meetup.Domain.WriteModel.Products
{
    public interface ICreateProduct
    {
        void Create(CreateProductCommand product);
    }
}
