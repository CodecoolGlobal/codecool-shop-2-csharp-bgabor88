using System.Collections.Generic;
using System.Linq;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Helpers;
using Codecool.CodecoolShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Codecool.CodecoolShop.Controllers
{
    [Route("payment")]
    public class PaymentController : Controller
    {
        [Route("index")]
        public IActionResult Index(IFormCollection collection)
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<Item>>("cart");

            IOrderDao orderDataStore = OrderDaoMemory.GetInstance();

            Order order = new Order 
            {   
                 ItemCollection = cart,
                 PaymentInfo = new PaymentInfo(),
                 Total = cart.Sum(item => item.Product.DefaultPrice * item.Quantity),
                 FullName = collection["fullname"],
                 Email = collection["email"],
                 Address = collection["address"],
                 City = collection["city"],
                 State = collection["state"],
                 Zip = collection["zip"],
                 FullNameShipping = collection["fullnameShipping"],
                 EmailShipping = collection["emailShipping"],
                 AddressShipping = collection["addressShipping"],
                 CityShipping = collection["cityShipping"],
                 StateShipping = collection["stateShipping"],
                 ZipShipping = collection["zipShipping"]
            };
            
            orderDataStore.Add(order);            

            return View();            
        }
    }
}
