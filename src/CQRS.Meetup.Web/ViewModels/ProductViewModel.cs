using System.ComponentModel.DataAnnotations;

namespace CQRS.Meetup.Web.ViewModels
{
    public class ProductViewModel
    {
        [Required]
        public string Name { get; set; }

        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        public ProductViewModel()
        {
        }

        public ProductViewModel(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }
    }
}
