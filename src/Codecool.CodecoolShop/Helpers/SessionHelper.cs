using Codecool.CodecoolShop.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Codecool.CodecoolShop.Helpers
{
    public static class SessionHelper
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }

        public static void SetCartSession(dynamic ViewBag, ISession session)
        {
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(session, "cart");
            if (cart != null)
            {
                ViewBag.cart = cart;
                ViewBag.itemQty = cart.Sum(item => item.Quantity);
            }
        }

        public static void SaveToJsonFile(Order value, int orderNumber)
        {
            //string jsonString = JsonConvert.SerializeObject(value);
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = System.Text.Json.JsonSerializer.Serialize(value, options);
            jsonString += System.Text.Json.JsonSerializer.Serialize(value.ItemCollection, options);
            File.WriteAllText($"../savedOrder{orderNumber}.json", jsonString);            
        }
    }
}