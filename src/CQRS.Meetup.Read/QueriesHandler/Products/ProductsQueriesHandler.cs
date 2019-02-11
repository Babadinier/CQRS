using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data.SqlClient;
using CQRS.Meetup.Read.Queries.Products;
using CQRS.Meetup.Read.ReadModel.Products;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace CQRS.Meetup.Read.QueriesHandler.Products
{
    public sealed class ProductsQueriesHandler : IQueryHandler<GetProductsQuery, IReadOnlyCollection<ProductDto>>
    {
        private readonly string _connectionString;

        public ProductsQueriesHandler(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IReadOnlyCollection<ProductDto> Handle(GetProductsQuery query)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var products = connection
                                .Query<ProductDto>(@"select Name, Quantity from Products order by Name, Quantity")
                                .ToImmutableList();

                return products;
            }
        }
    }
}