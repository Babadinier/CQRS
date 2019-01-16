using System.Collections.Generic;
using System.Linq;
using CQRS.Meetup.Domain.Queries.Products;
using CQRS.Meetup.Domain.ReadModel.Products;

namespace CQRS.Meetup.Domain.QueriesHandler.Products
{
    public sealed class GetListQueryHandler : IQueryHandler<GetListQuery, List<ProductDto>>
    {
        private readonly IProvideProduct _provideProductRepository;

        public GetListQueryHandler(IProvideProduct provideProductRepository)
        {
            _provideProductRepository = provideProductRepository;
        }

        public List<ProductDto> Handle(GetListQuery query)
        {
            return _provideProductRepository.RetrieveProducts().ToList();
        }
    }
}