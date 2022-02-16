using System.Collections.Generic;
using System.Linq;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Daos.Implementations
{
    public class ProductCategoryDaoDb : IProductCategoryDao
    {
        private List<ProductCategory> _data;

        public ProductCategoryDaoDb(ProductContext context)
        {
            _data = context.Category.ToList();
        }

        public void Add(ProductCategory item)
        {
            item.Id = _data.Count + 1;
            _data.Add(item);
        }

        public void Remove(int id)
        {
            _data.Remove(this.Get(id));
        }

        public ProductCategory Get(int id)
        {
            return _data.Find(x => x.Id == id);
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            return _data;
        }

        public ProductCategory Get(string categoryName)
        {
            return _data.Find(x => x.Name == categoryName);
        }
    }
}
