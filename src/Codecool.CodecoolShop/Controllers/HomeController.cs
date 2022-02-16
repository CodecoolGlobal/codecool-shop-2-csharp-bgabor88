using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Helpers;
using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace Codecool.CodecoolShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductService _productService;

        public HomeController(ProductService service)
        {
            _productService = service;
        }

        public IActionResult Index()
        {
            SessionHelper.SetCartSession(ViewBag, HttpContext.Session);

            var featuredProducts = new List<IEnumerable<Product>>
            {
                _productService.GetFilteredProducts("Sony", "All").OrderByDescending(x => x.DefaultPrice).Take(3),
                _productService.GetFilteredProducts("Nikon", "All").OrderByDescending(x => x.DefaultPrice).Take(3),
                _productService.GetFilteredProducts("Canon", "All").OrderByDescending(x => x.DefaultPrice).Take(3)
            };

            return View(featuredProducts);
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
