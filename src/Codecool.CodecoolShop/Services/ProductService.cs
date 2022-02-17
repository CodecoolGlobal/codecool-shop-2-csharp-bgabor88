using System;
using System.Collections.Generic;
using System.Linq;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Services
{
    public class ProductService
    {
        private readonly IProductDao _productDao;
        private readonly IProductCategoryDao _productCategoryDao;
        private readonly ISupplierDao _supplierDao;

        public ProductService(IProductDao productDao, IProductCategoryDao productCategoryDao, ISupplierDao supplierDao)
        {
            this._productDao = productDao;
            this._productCategoryDao = productCategoryDao;
            this._supplierDao = supplierDao;
        }

        public ProductService()
        {
            this._productDao = ProductDaoMemory.GetInstance();
            this._productCategoryDao = ProductCategoryDaoMemory.GetInstance();
            this._supplierDao = SupplierDaoMemory.GetInstance();
        }

        public ProductCategory GetProductCategory(int categoryId)
        {
            var result = this._productCategoryDao.Get(categoryId);
            if (result == null)
            {
                throw new ArgumentException("There is not any Product Category by this ID!");
            }

            return result;
        }

        public IEnumerable<Product> GetProductsForCategory(int categoryId)
        {
            var category = this._productCategoryDao.Get(categoryId);
            if (category == null)
            {
                throw new ArgumentException("There is not any Product by this Category ID!");
            }

            var result = this._productDao.GetBy(category);
            return result;
        }

        public IEnumerable<Product> GetFilteredProducts(string supplierName, string categoryName)
        {
            ProductCategory category;
            Supplier supplier;

            if (supplierName == "All" && categoryName != "All")
            {
                category = this._productCategoryDao.Get(categoryName);
                return this._productDao.GetBy(category);
            }

            if (supplierName != "All" && categoryName == "All")
            {
                supplier = _supplierDao.GetAll().FirstOrDefault(x => x.Name == supplierName);
                return this._productDao.GetBy(supplier);
            }

            category = this._productCategoryDao.Get(categoryName);
            supplier = _supplierDao.GetAll().FirstOrDefault(x => x.Name == supplierName);

            return this._productDao.GetBy(category, supplier);
        }

        public IEnumerable<Product> GetAll()
        {
            return this._productDao.GetAll();
        }

        public Product GetProductById(int id)
        {
            var result = this._productDao.Get(id);
            if (result == null)
            {
                throw new ArgumentException("There is not any Product by this ID!");
            }

            return result;
        }
    }
}
