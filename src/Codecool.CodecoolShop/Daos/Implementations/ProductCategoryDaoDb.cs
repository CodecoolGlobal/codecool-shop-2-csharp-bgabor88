using System.Collections.Generic;
using System.Linq;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Daos.Implementations
{
    class ProductCategoryDaoDb : IProductCategoryDao
    {
        private List<ProductCategory> data;
        //private static ProductCategoryDaoDb instance;

        public ProductCategoryDaoDb(ProductContext context)
        {
            //instance = this;
            data = context.Category.ToList();
        }

        //public static ProductCategoryDaoDb GetInstance()
        //{
        //    //if (instance == null)
        //    //{
        //    //    instance = new ProductCategoryDaoDb();
        //    //}

        //    return instance;
        //}

        public void Add(ProductCategory item)
        {
            item.Id = data.Count + 1;
            data.Add(item);
        }

        public void Remove(int id)
        {
            data.Remove(this.Get(id));
        }

        public ProductCategory Get(int id)
        {
            return data.Find(x => x.Id == id);
        }

        //public ProductCategory Get(string category)
        //{
        //    return data.Find(x => x.Name == category);
        //}

        public IEnumerable<ProductCategory> GetAll()
        {
            return data;
        }

        public ProductCategory Get(string categoryName)
        {
            return data.Find(x => x.Name == categoryName);
        }
    }
}
