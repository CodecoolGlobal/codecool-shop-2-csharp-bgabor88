using System.Collections.Generic;
using System.Linq;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Daos.Implementations
{
    public class SupplierDaoDb : ISupplierDao
    {
        private List<Supplier> _data;

        public SupplierDaoDb(ProductContext context)
        {
            _data = context.Supplier.ToList();
        }

        public void Add(Supplier item)
        {
            item.Id = _data.Count + 1;
            _data.Add(item);
        }

        public void Remove(int id)
        {
            _data.Remove(this.Get(id));
        }

        public Supplier Get(int id)
        {
            return _data.Find(x => x.Id == id);
        }

        public IEnumerable<Supplier> GetAll()
        {
            return _data;
        }
    }
}
