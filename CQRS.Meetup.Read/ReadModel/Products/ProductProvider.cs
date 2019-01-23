using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace CQRS.Meetup.Read.ReadModel.Products
{
    public class ProductProvider : IProvideProduct
    {
        private const string connectionString = "Server=localhost;Database=CQRS;Trusted_Connection=True;";
        public IEnumerable<ProductDto> RetrieveProducts()
        {
            using (var connection = new SqlConnection(connectionString))
            {
               var products = connection.Query<ProductDto>(@"select * from Products order by Name, Quantity");
               return products;
            }
        }
    }
}