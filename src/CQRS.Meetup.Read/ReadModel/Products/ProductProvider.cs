using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace CQRS.Meetup.Read.ReadModel.Products
{
    public class ProductProvider : IProvideProduct
    {
        private readonly string _connectionString;

        public ProductProvider(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<ProductDto> RetrieveProducts()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
               var products = connection.Query<ProductDto>(@"select * from Products order by Name, Quantity");
               return products;
            }
        }
    }
}