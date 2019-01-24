using System.Collections.Generic;
using CQRS.Meetup.Read.ReadModel;
using CQRS.Meetup.Read.ReadModel.Products;

namespace CQRS.Meetup.Read.Queries.Products
{
    public sealed class GetProductsQuery : IQuery<List<ProductDto>>
    {

    }
}