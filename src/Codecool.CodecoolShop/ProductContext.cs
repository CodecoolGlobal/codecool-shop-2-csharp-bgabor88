using Codecool.CodecoolShop.Models;
using Microsoft.EntityFrameworkCore;

namespace Codecool.CodecoolShop
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions options) : base(options) {}
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductCategory> Category { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
    }
}
