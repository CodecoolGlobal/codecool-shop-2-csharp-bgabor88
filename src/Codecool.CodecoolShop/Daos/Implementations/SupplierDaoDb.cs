using System.Collections.Generic;
using System.Linq;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Daos.Implementations
{
    public class SupplierDaoDb : ISupplierDao
    {
        private List<Supplier> data;
        //private static SupplierDaoDb instance = null;

        public SupplierDaoDb(ProductContext context)
        {
            //instance = this;
            data = context.Supplier.ToList();
        }

        //public static SupplierDaoDb GetInstance()
        //{
        //    if (instance == null)
        //    {
        //        instance = new SupplierDaoDb();
        //    }

        //    return instance;
        //}

        public void Add(Supplier item)
        {
            item.Id = data.Count + 1;
            data.Add(item);
        }

        public void Remove(int id)
        {
            data.Remove(this.Get(id));
        }

        public Supplier Get(int id)
        {
            return data.Find(x => x.Id == id);
        }

        public IEnumerable<Supplier> GetAll()
        {
            return data;
        }
    }
}
