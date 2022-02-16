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
        private ProductService _productService;
        //private ProductContext _context;

        public HomeController(ProductService service)
        {
            _productService = service;
            //_context = context;
            //_productService = new ProductService(
            //    ProductDaoMemory.GetInstance(),
            //    ProductCategoryDaoMemory.GetInstance());
        }

        public IActionResult Index()
        {
            SessionHelper.SetCartSession(ViewBag, HttpContext.Session);

            var featuredProducts = new List<IEnumerable<Product>>
            {
                //_context.Product.Where(p => p.Supplier.Name == "Sony").OrderByDescending(x => x.DefaultPrice).Take(3).ToList(),
                //_context.Product.Where(p => p.Supplier.Name == "Nikon").OrderByDescending(x => x.DefaultPrice).Take(3).ToList(),
                //_context.Product.Where(p => p.Supplier.Name == "Canon").OrderByDescending(x => x.DefaultPrice).Take(3).ToList(),
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
