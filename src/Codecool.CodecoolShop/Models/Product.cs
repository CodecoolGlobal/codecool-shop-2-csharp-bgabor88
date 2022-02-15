using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codecool.CodecoolShop.Models
{
    public class Product : BaseModel
    {
        public string Currency { get; set; }

        [Column(TypeName = "decimal(20,2)")]
        public decimal DefaultPrice { get; set; }

        [ForeignKey("ProductCategoryId")]
        public ProductCategory ProductCategory { get; set; }

        [ForeignKey("SupplierId")]
        public Supplier Supplier { get; set; }

        public void SetProductCategory(ProductCategory productCategory)
        {
            ProductCategory = productCategory;
            ProductCategory.Products.Add(this);
        }
    }
}
