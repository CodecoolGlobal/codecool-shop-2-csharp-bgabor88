using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Codecool.CodecoolShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Codecool.CodecoolShop.Helpers;
using Codecool.CodecoolShop.Daos.Implementations;

namespace Codecool.CodecoolShop.Controllers
{
    [Route("checkout")]
    public class CheckoutController : Controller
    {
        [Route("index")]
        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            ViewBag.itemQty = cart.Sum(item => item.Quantity);
            ViewBag.total = cart.Sum(item => item.Product.DefaultPrice * item.Quantity);
            return View();
        }
    }
}