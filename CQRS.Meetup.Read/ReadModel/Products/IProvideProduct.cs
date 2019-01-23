using System.Collections.Generic;

namespace CQRS.Meetup.Read.ReadModel.Products
{
    public interface IProvideProduct
    {
        IEnumerable<ProductDto> RetrieveProducts();
    }
}
