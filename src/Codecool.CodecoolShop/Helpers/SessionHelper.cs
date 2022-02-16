using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Codecool.CodecoolShop.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

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
            var cart = session.GetObjectFromJson<List<Item>>("cart");
            if (cart != null)
            {
                ViewBag.cart = cart;
                ViewBag.itemQty = cart.Sum(item => item.Quantity);
            }
        }

        public static void SaveToJsonFile(Order value, int orderNumber)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(value, options);
            jsonString += JsonSerializer.Serialize(value.ItemCollection, options);
            File.WriteAllText($"../savedOrder{orderNumber}.json", jsonString);            
        }
    }
}