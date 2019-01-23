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
    //todo gub : use CommandBus or Messages ? 
    public class ProductController : Controller
    {
        //With CommandBus
        //private readonly ICommandSender _commandBus;
        //public ProductController(ICommandSender commandBus, IProvideProduct provideProduct)
        //{
        //    _commandBus = commandBus;
        //    _provideProduct = provideProduct;
        //}

        //private readonly IProvideProduct _provideProduct;
        private readonly CommandProcessor _commandProcessor;
        private readonly QueryProcessor _queryProcessor;

        public ProductController(CommandProcessor commandProcessor, QueryProcessor queryProcessor)
        {
            _commandProcessor = commandProcessor;
            _queryProcessor = queryProcessor;
            //_provideProduct = provideProduct;
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

            //With IProvideProduct
            //var products = _provideProduct.RetrieveProducts();
            //return View(products);

            var products = _queryProcessor.Dispatch(new GetProductsQuery());
            return View(products);
        }
    }
}