using CQRS.Meetup.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CQRS.Meetup.Infra;
using CQRS.Meetup.Read;
using CQRS.Meetup.Read.Queries.Products;
using CQRS.Meetup.Read.ReadModel.Products;
using CQRS.Meetup.Write;
using CQRS.Meetup.Write.Commands.Products;

namespace CQRS.Meetup.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly CommandProcessor _commandProcessor;
        private readonly QueryProcessor _queryProcessor;

        public ProductController(CommandProcessor commandProcessor, QueryProcessor queryProcessor)
        {
            _commandProcessor = commandProcessor;
            _queryProcessor = queryProcessor;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductViewModel product)
        {
            var command = new CreateProductCommand(product.Name, product.Quantity);
            _commandProcessor.Dispatch(command);

            return RedirectToAction("Products");
        }

        [HttpGet]
        public IActionResult Products()
        {
            var products = _queryProcessor.Dispatch(new GetProductsQuery());
            return View(products);
        }
    }
}