using System;

namespace CQRS.Meetup.Domain.WriteModel
{
    //todo gub : better place ? need to deplace it in data (and create another model for write)
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }

        public Product(Guid id, string name, int quantity)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
        }

        public Product()
        {

        }
    }
}