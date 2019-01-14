using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Meetup.Web.ViewModels
{
    public class ProductViewModel
    {
        public string Name { get; set; }
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
