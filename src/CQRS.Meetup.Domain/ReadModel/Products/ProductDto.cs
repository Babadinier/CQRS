using System;

namespace CQRS.Meetup.Domain.ReadModel.Products
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}
