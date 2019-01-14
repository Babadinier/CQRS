namespace CQRS.Meetup.Domain.Commands
{
    public class CreateProductCommand : ICommand
    {
        public string Name { get; set; }
        public int Quantity { get; set; }

        public CreateProductCommand(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }
    }
}
