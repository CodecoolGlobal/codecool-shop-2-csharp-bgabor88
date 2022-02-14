using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Services;
using Codecool.CodecoolShop.Helpers;

namespace Codecool.CodecoolShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        public ProductService ProductService { get; set; }

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
            ProductService = new ProductService(
                ProductDaoMemory.GetInstance(),
                ProductCategoryDaoMemory.GetInstance());
        }
        
        public IActionResult Index()
        {
            SessionHelper.SetCartSession(ViewBag, HttpContext.Session);
            var products = ProductService.GetAll().OrderBy(x => x.DefaultPrice);
            return View(products.ToList());
        }

        [Route("Product/{brand}/{category}")]
        public IActionResult Products(string brand, string category)
        {
            var products = ProductService.GetFilteredProducts(brand, category).OrderByDescending(x => x.DefaultPrice);
            return PartialView(viewName: "_products", products.ToList());
        }
    }
}
