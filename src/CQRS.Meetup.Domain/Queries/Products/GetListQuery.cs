using System.Collections.Generic;
using CQRS.Meetup.Domain.ReadModel;
using CQRS.Meetup.Domain.ReadModel.Products;

namespace CQRS.Meetup.Domain.Queries.Products
{
    public sealed class GetListQuery : IQuery<List<ProductDto>>
    {

    }
}