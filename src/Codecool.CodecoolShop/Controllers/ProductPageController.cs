using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Helpers;
using Codecool.CodecoolShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace Codecool.CodecoolShop.Controllers
{
    public class ProductPageController : Controller
    {
        private readonly ProductService _productService;
        public ProductPageController(ProductService service)
        {
            _productService = service;
        }

        [Route("Product/{id:int}")]
        public IActionResult Index(int id)
        {
            SessionHelper.SetCartSession(ViewBag, HttpContext.Session);
            var product = _productService.GetProductById(id);
            return View(product);
        }
    }
}
