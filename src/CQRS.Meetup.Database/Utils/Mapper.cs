using CQRS.Meetup.Data.Models;
using CQRS.Meetup.Domain.ReadModel.Products;

namespace CQRS.Meetup.Data.Utils
{
    public static class Mapper
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