using CQRS.Meetup.Data.CommandBus;
using CQRS.Meetup.Domain.Commands;
using CQRS.Meetup.Domain.ReadModel;
using CQRS.Meetup.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Meetup.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ICommandSender _commandBus;
        private readonly IProvideProduct _provideProduct;

        public ProductController(ICommandSender commandBus, IProvideProduct provideProduct)
        {
            _commandBus = commandBus;
            _provideProduct = provideProduct;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductViewModel product)
        {
            var command = new CreateProductCommand(product.Name, product.Quantity);
            _commandBus.Send(command);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Products()
        {
            var products = _provideProduct.GetAllProducts();
            return View(products);
        }
    }
}