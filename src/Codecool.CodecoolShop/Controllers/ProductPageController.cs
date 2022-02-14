using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Helpers;
using Codecool.CodecoolShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace Codecool.CodecoolShop.Controllers
{
    public class ProductPageController : Controller
    {
        private readonly ProductDaoMemory _products;
        public ProductPageController()
        {
            _products = ProductDaoMemory.GetInstance();
        }

        [Route("Product/{id:int}")]
        public IActionResult Index(int id)
        {
            SessionHelper.SetCartSession(ViewBag, HttpContext.Session);
            var product = _products.Get(id);
            return View(product);
        }
    }
}
