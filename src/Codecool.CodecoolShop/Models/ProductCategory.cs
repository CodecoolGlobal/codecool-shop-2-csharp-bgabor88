using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Codecool.CodecoolShop.Models
{
    public class ProductCategory: BaseModel
    {
        public virtual List<Product> Products { get; set; }
        public string Department { get; set; }
    }
}
