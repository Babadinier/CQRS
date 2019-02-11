using System;
using CQRS.Meetup.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using CQRS.Meetup.Infra;
using CQRS.Meetup.Read.Queries.Products;
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
            if(!ModelState.IsValid)
            {
                return View("Index", product);
            }

            try
            {
                var command = new CreateProductCommand(product.Name, product.Quantity);
                _commandProcessor.Dispatch(command);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View("Index", product);
            }

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