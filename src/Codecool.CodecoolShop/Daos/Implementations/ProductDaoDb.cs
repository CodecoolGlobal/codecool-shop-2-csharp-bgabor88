using System.Collections.Generic;
using System.Linq;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Daos.Implementations
{
    public class ProductDaoDb : IProductDao
    {
        private List<Product> _data;

        public ProductDaoDb(ProductContext context)
        {
            _data = context.Product.ToList();
        }

        public void Add(Product item)
        {
            item.Id = _data.Count + 1;
            _data.Add(item);
        }

        public void Remove(int id)
        {
            _data.Remove(this.Get(id));
        }

        public Product Get(int id)
        {
            return _data.Find(x => x.Id == id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _data;
        }

        public IEnumerable<Product> GetBy(Supplier supplier)
        {
            return _data.Where(x => x.Supplier.Id == supplier.Id);
        }

        public IEnumerable<Product> GetBy(ProductCategory productCategory)
        {
            return _data.Where(x => x.ProductCategory.Id == productCategory.Id);
        }

        public IEnumerable<Product> GetBy(string supplier)
        {
            return _data.Where(x => x.Supplier.Name == supplier);
        }

        public IEnumerable<Product> GetBy(ProductCategory productCategory, Supplier supplier)
        {
            return _data.Where(x => x.Supplier == supplier && x.ProductCategory == productCategory);
        }
    }
}
