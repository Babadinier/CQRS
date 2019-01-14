using System.Collections.Generic;

namespace CQRS.Meetup.Domain.ReadModel
{
    public interface IProvideProduct
    {
        IEnumerable<ProductDto> GetAllProducts();
    }
}
