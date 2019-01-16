namespace CQRS.Meetup.Domain.Commands.Products
{
    public class CreateProductCommand : ICommand
    {
        public string Name { get; }
        public int Quantity { get; }

        public CreateProductCommand(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }
    }
}
