using CQRS.Meetup.Domain;
using CQRS.Meetup.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CQRS.Meetup.Domain.Commands.Products;
using CQRS.Meetup.Domain.Queries.Products;
using CQRS.Meetup.Domain.ReadModel.Products;

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

        private readonly IProvideProduct _provideProduct;
        private readonly Messages _messages;

        public ProductController(Messages messages, IProvideProduct provideProduct)
        {
            _messages = messages;
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
            _messages.Dispatch(command);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Products()
        {

            //With IProvideProduct
            //var products = _provideProduct.RetrieveProducts();
            //return View(products);

            List<ProductDto> products = _messages.Dispatch(new GetListQuery());
            return View(products);
        }
    }
}