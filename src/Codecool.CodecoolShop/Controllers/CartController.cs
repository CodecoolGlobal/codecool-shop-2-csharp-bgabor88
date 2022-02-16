using System.Collections.Generic;
using System.Linq;
using Codecool.CodecoolShop.Helpers;
using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace Codecool.CodecoolShop.Controllers
{
    [Route("cart")]
    public class CartController : Controller
    {
        private readonly ProductService _productService;

        public CartController(ProductService service)
        {
            _productService = service;
        }

        [Route("index")]
        public IActionResult Index()
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<Item>>("cart");          
            ViewBag.cart = cart;
            ViewBag.itemQty = cart.Sum(item => item.Quantity);
            ViewBag.total = cart.Sum(item => item.Product.DefaultPrice * item.Quantity);
            return View();
        }

        [Route("buy/{id}")]
        public IActionResult Buy(int id)
        {
            if (HttpContext.Session.GetObjectFromJson<List<Item>>("cart") == null)
            {
                List<Item> cart = new List<Item>
                {
                    new Item { Product = _productService.GetProductById(id), Quantity = 1 }
                };
                HttpContext.Session.SetObjectAsJson("cart", cart);
            }
            else
            {
                List<Item> cart = HttpContext.Session.GetObjectFromJson<List<Item>>("cart");
                int index = IsExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new Item { Product = _productService.GetProductById(id), Quantity = 1 });
                }
                HttpContext.Session.SetObjectAsJson("cart", cart);
            }
            return RedirectToAction("Index");
        }

        [Route("remove/{id}")]
        public IActionResult Remove(int id)
        {
            List<Item> cart = HttpContext.Session.GetObjectFromJson<List<Item>>("cart");
            int index = IsExist(id);
            if (cart[index].Quantity > 1)
            {
                cart[index].Quantity--;
            }
            else
            {
                cart.RemoveAt(index);
            }
            HttpContext.Session.SetObjectAsJson("cart", cart);
            return RedirectToAction("Index");
        }

        private int IsExist(int id)
        {
            List<Item> cart = HttpContext.Session.GetObjectFromJson<List<Item>>("cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.Id.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }

    }
}