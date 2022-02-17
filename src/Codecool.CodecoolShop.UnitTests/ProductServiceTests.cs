using NUnit.Framework;

namespace Codecool.CodecoolShop.UnitTests
{
    public class ProductServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetProductCategory_ValidCategoryId_ReturnsProductCategory()
        {
            Assert.Pass();
        }

        public void GetProductsForCategory_ValidCategoryId_ReturnsProductsForCategory()
        {
            Assert.Pass();
        }

        public void GetFilteredProducts_ValidSupplierName_ReturnsProductsOfSupplier()
        {
            Assert.Pass();
        }

        public void GetFilteredProducts_ValidCategoryName_ReturnsProductsOfCategory()
        {
            Assert.Pass();
        }

        public void GetFilteredProducts_ValidSupplierAndCategoryName_ReturnsProductsFilteredBySupplierAndCategory()
        {
            Assert.Pass();
        }

        public void GetAll_ReturnsAllProducts()
        {
            Assert.Pass();
        }

        public void GetProductById_ValidId_ReturnsCorrectProduct()
        {
            Assert.Pass();
        }
    }
}