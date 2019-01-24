using System.Collections.Generic;
using System.Linq;
using CQRS.Meetup.Read.Queries.Products;
using CQRS.Meetup.Read.ReadModel.Products;

namespace CQRS.Meetup.Read.QueriesHandler.Products
{
    public sealed class GetListQueryHandler : IQueryHandler<GetProductsQuery, List<ProductDto>>
    {
        private readonly IProvideProduct _provideProductRepository;

        public GetListQueryHandler(IProvideProduct provideProductRepository)
        {
            _provideProductRepository = provideProductRepository;
        }

        public List<ProductDto> Handle(GetProductsQuery query)
        {
            return _provideProductRepository.RetrieveProducts().ToList();
        }
    }
}