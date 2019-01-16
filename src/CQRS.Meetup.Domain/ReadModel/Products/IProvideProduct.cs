using System.Collections.Generic;

namespace CQRS.Meetup.Domain.ReadModel.Products
{
    public interface IProvideProduct
    {
        IEnumerable<ProductDto> RetrieveProducts();
    }
}
