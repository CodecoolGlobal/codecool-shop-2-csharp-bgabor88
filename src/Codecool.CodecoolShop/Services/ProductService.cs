using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Services
{
    public class ProductService
    {
        private readonly IProductDao productDao;
        private readonly IProductCategoryDao productCategoryDao;

        public ProductService(IProductDao productDao, IProductCategoryDao productCategoryDao)
        {
            this.productDao = productDao;
            this.productCategoryDao = productCategoryDao;
        }

        public ProductCategory GetProductCategory(int categoryId)
        {
            return this.productCategoryDao.Get(categoryId);
        }

        public IEnumerable<Product> GetProductsForCategory(int categoryId)
        {
            ProductCategory category = this.productCategoryDao.Get(categoryId);
            return this.productDao.GetBy(category);
        }
        public IEnumerable<Product> GetFilteredProducts(string supplierName, string categoryName)
        {
            ProductCategory category;
            Supplier supplier;

            if (supplierName == "All" && categoryName != "All")
            {
                category = this.productCategoryDao.Get(categoryName);
                return this.productDao.GetBy(category);
            }

            if (supplierName != "All" && categoryName == "All")
            {
                supplier = SupplierDaoMemory.GetInstance().GetAll().FirstOrDefault(x => x.Name == supplierName);
                return this.productDao.GetBy(supplier);
            }

            category = this.productCategoryDao.Get(categoryName);
            supplier = SupplierDaoMemory.GetInstance().GetAll().FirstOrDefault(x => x.Name == supplierName);

            return this.productDao.GetBy(category, supplier);
        }

        public IEnumerable<Product> GetAll()
        {
            return this.productDao.GetAll();
        }
    }
}
