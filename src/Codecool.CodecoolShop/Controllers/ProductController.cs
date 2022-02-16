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
        private readonly ProductService _productService;

        public ProductController(ILogger<ProductController> logger, ProductService service)
        {
            _logger = logger;
            _productService = service;
        }
        
        public IActionResult Index()
        {
            SessionHelper.SetCartSession(ViewBag, HttpContext.Session);
            var products = _productService.GetAll().OrderBy(x => x.DefaultPrice);
            return View(products.ToList());
        }

        [Route("Product/{brand}/{category}")]
        public IActionResult Products(string brand, string category)
        {
            var products = _productService.GetFilteredProducts(brand, category).OrderByDescending(x => x.DefaultPrice);
            return PartialView(viewName: "_products", products.ToList());
        }
    }
}
