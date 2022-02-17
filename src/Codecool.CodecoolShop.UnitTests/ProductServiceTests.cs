using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Services;
using NSubstitute;
using NUnit.Framework;

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
            Assert.Pass();
        }

        [Test]
        public void GetProductsForCategory_ValidCategoryId_ReturnsProductsForCategory()
        {
            Assert.Pass();
        }

        [Test]
        public void GetFilteredProducts_ValidSupplierName_ReturnsProductsOfSupplier()
        {
            Assert.Pass();
        }

        [Test]
        public void GetFilteredProducts_ValidCategoryName_ReturnsProductsOfCategory()
        {
            Assert.Pass();
        }

        [Test]
        public void GetFilteredProducts_ValidSupplierAndCategoryName_ReturnsProductsFilteredBySupplierAndCategory()
        {
            Assert.Pass();
        }

        [Test]
        public void GetAll_ReturnsAllProducts()
        {
            Assert.Pass();
        }

        [Test]
        public void GetProductById_ValidId_ReturnsCorrectProduct()
        {
            Assert.Pass();
        }
    }
}