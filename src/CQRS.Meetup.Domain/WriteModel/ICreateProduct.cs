namespace CQRS.Meetup.Domain.WriteModel
{
    public interface ICreateProduct
    {
        void Create(Product product);
    }
}
