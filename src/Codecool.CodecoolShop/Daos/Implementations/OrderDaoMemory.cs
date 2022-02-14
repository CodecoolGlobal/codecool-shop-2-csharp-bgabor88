using System.Collections.Generic;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Daos.Implementations
{
    public class OrderDaoMemory : IOrderDao
    {
        private List<Order> data = new List<Order>();
        private static OrderDaoMemory instance = null;

        private OrderDaoMemory()
        {
        }

        public static OrderDaoMemory GetInstance()
        {
            if (instance == null)
            {
                instance = new OrderDaoMemory();
            }

            return instance;
        }

        public void Add(Order item)
        {
            item.Id = data.Count + 1;
            data.Add(item);
        }

        public void Remove(int id)
        {
            data.Remove(this.Get(id));
        }

        public Order Get(int id)
        {
            return data.Find(x => x.Id == id);
        }

        public IEnumerable<Order> GetAll()
        {
            return data;
        }
    }
}
