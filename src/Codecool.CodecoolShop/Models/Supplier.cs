using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codecool.CodecoolShop.Models
{
    public class Supplier : BaseModel
    {
        [NotMapped]
        public IEnumerable<Product> Products { get; set; }
        
        public override string ToString()
        {
            return new string($"Id: {Id} Name: {Name} Description: {Description}");
        }
    }
}
