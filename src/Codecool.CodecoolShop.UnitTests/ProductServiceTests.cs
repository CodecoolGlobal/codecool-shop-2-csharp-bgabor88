using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Services;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NSubstitute.ReturnsExtensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Codecool.CodecoolShop.UnitTests
{
    [TestFixture]
    public class ProductServiceTests
    {
        private IProductCategoryDao _categoryDao;
        private ISupplierDao _supplierDao;
        private IProductDao _productDao;
        private ProductService _productService;

        [SetUp]
        public void Setup()
        {
            _categoryDao = Substitute.For<IProductCategoryDao>();
            _supplierDao = Substitute.For<ISupplierDao>();
            _productDao = Substitute.For<IProductDao>();
            _productService = new ProductService(_productDao, _categoryDao, _supplierDao);
        }

        [Test]
        public void GetProductCategory_ValidCategoryId_ReturnsProductCategory()
        {
            //Arrange

            var category = new ProductCategory() { Id = 1, Name = "TestCategory"};
            _categoryDao.Get(1).Returns(category);

            //Act

            var result = _productService.GetProductCategory(1);

            //Assert

            Assert.AreEqual(category, result);

        }

        [Test]
        public void GetProductCategory_InvalidCategoryId_ThrowsArgumentException()
        {
            //Arrange

            _categoryDao.Get(1).ReturnsNull();

            //Act

            //Assert

            Assert.Throws<ArgumentException>(() =>
            {
                _productService.GetProductCategory(1);
            });

        }

        [Test]
        public void GetProductsForCategory_ValidCategoryId_ReturnsProductsForCategory()
        {
            //Arrange

            var category = new ProductCategory() { Id = 1, Name = "TestCategory" };
            _categoryDao.Get(1).Returns(category);
            IEnumerable<Product> productList = new List<Product>()
            {
                new Product() { Id = 1, Name = "TestProduct1" },
                new Product() { Id = 2, Name = "TestProduct2" }
            };

            _productDao.GetBy(category).Returns(productList);

            //Act

            var result = _productService.GetProductsForCategory(1);

            //Assert

            Assert.AreEqual(productList, result);

        }

        [Test]
        public void GetProductsForCategory_InvalidCategoryId_ThrowsArgumentException()
        {
            //Arrange

            _categoryDao.Get(1).ReturnsNull();

            //Act

            //Assert

            Assert.Throws<ArgumentException>(() =>
            {
                _productService.GetProductsForCategory(1);
            });

        }

        [Test]
        public void GetFilteredProducts_ValidSupplierName_ReturnsProductsOfSupplier()
        {
            //Arrange

            IEnumerable<Product> productList = new List<Product>()
            {
                new Product() { Id = 1, Name = "TestProduct1" },
                new Product() { Id = 2, Name = "TestProduct2" }
            };
            IEnumerable<Supplier> supplierList = new List<Supplier>()
            {
                new Supplier { Id = 1, Name = "TestSupplier1" },
                new Supplier { Id = 2, Name = "TestSupplier2" }
            };
            _supplierDao.GetAll().Returns(supplierList);
            _productDao.GetBy(supplierList.FirstOrDefault()).Returns(productList);

            //Act

            var result = _productService.GetFilteredProducts("TestSupplier1", "All");

            //Assert
            
            Assert.AreEqual(productList, result);

        }

        [Test]
        public void GetFilteredProducts_ValidCategoryName_ReturnsProductsOfCategory()
        {
            //Arrange

            IEnumerable<Product> productList = new List<Product>()
            {
                new Product() { Id = 1, Name = "TestProduct1" },
                new Product() { Id = 2, Name = "TestProduct2" }
            };
            var category = new ProductCategory() { Id = 1, Name = "TestCategory" };
            _categoryDao.Get("TestCategory").Returns(category);
            _productDao.GetBy(category).Returns(productList);

            //Act

            var result = _productService.GetFilteredProducts("All", "TestCategory");

            //Assert

            Assert.AreEqual(productList, result);

        }

        [Test]
        public void GetFilteredProducts_ValidSupplierAndCategoryName_ReturnsProductsFilteredBySupplierAndCategory()
        {
            //Arrange

            IEnumerable<Product> productList = new List<Product>()
            {
                new Product() { Id = 1, Name = "TestProduct1" },
                new Product() { Id = 2, Name = "TestProduct2" }
            };

            var category = new ProductCategory() { Id = 1, Name = "TestCategory" };
            _categoryDao.Get("TestCategory").Returns(category);

            IEnumerable<Supplier> supplierList = new List<Supplier>()
            {
                new Supplier { Id = 1, Name = "TestSupplier1" },
                new Supplier { Id = 2, Name = "TestSupplier2" }
            };
            _supplierDao.GetAll().Returns(supplierList);
            _productDao.GetBy(category, supplierList.FirstOrDefault()).Returns(productList);

            //Act

            var result = _productService.GetFilteredProducts("TestSupplier1", "TestCategory");

            //Assert

            Assert.AreEqual(productList, result);
        }

        [Test]
        public void GetAll_ReturnsAllProducts()
        {
            //Arrange

            IEnumerable<Product> productList = new List<Product>()
            {
                new Product() { Id = 1, Name = "TestProduct1" },
                new Product() { Id = 2, Name = "TestProduct2" }
            };

            _productDao.GetAll().Returns(productList);

            //Act

            var result = _productService.GetAll();

            //Assert
            
            Assert.AreEqual(productList, result);

        }

        [Test]
        public void GetAll_ServerDown_ThrowsIoException()
        {
            //Arrange

            _productDao.GetAll().Throws(new IOException());

            //Act

            //Assert

            Assert.Throws<IOException>(() =>
            {
                _productService.GetAll();
            });

        }

        [Test]
        public void GetProductById_ValidId_ReturnsCorrectProduct()
        {
            //Arrange

            var product = new Product() { Id = 1, Name = "TestProduct1" };
            _productDao.Get(1).Returns(product);

            //Act

            var result = _productService.GetProductById(1);

            //Assert

            Assert.AreEqual(product, result);

        }

        [Test]
        public void GetProductById_InvalidId_ThrowsArgumentException()
        {
            //Arrange

            _productDao.Get(1).ReturnsNull();

            //Act

            //Assert

            Assert.Throws<ArgumentException>(() =>
            {
                _productService.GetProductById(1);
            });

        }
    }
}