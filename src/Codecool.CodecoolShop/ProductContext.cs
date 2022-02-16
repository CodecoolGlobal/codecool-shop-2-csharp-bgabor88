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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
                .Property(p => p.DefaultPrice)
                .HasColumnType("decimal(20,2)");

            var canon = new Supplier { Id = 1, Name = "Canon", Description = "Canon Inc. (キヤノンキャノン株式会社) is a Japanese multinational corporation headquartered in Ōta, Tokyo, Japan, specializing in optical, imaging, and industrial products, such as lenses, cameras, medical equipment, scanners, printers, and semiconductor manufacturing equipment." };
            var nikon = new Supplier { Id = 2, Name = "Nikon", Description = "Nikon Corporation (株式会社ニコン), also known just as Nikon, is a Japanese multinational corporation headquartered in Tokyo, Japan, specializing in optics and imaging products. The companies held by Nikon form the Nikon Group." };
            var sony = new Supplier { Id = 3, Name = "Sony", Description = "Sony Group Corporation (ソニーグループ株式会社), commonly known as Sony and stylized as SONY, is a Japanese multinational conglomerate corporation headquartered in Kōnan, Minato, Tokyo, Japan." };

            var lens = new ProductCategory { Id = 1, Name = "Lens", Department = "Camera Lens", Description = "Quality lenses from the top Camera manufacturers." };
            var body = new ProductCategory { Id = 2, Name = "Body", Department = "Camera Body", Description = "Top of the line Mirrorless digital camera bodies." };

            modelBuilder.Entity<Supplier>().HasData(canon, nikon, sony);

            modelBuilder.Entity<ProductCategory>().HasData(lens, body);
            
            modelBuilder.Entity<Product>().HasData(
                new Product{ SupplierId = canon.Id, ProductCategoryId = lens.Id, Id = 1, Name = "Canon RF 15-35mm f2.8 L IS USM", DefaultPrice = 1849m, Currency = "EUR", Description = "The Canon RF 15-35mm f/2.8 is a full-frame pro wide-angle zoom lens offering superior performance thanks to a Nano USM motor, 5-stops of image stabilisation plus 3 Aspherical and 2 UD elements for stunning sharpness." },
                new Product{ SupplierId = canon.Id, ProductCategoryId = lens.Id, Id = 2, Name = "Canon RF 85mm f1.2 L IS USM", DefaultPrice = 2349m, Currency = "EUR", Description = "The Canon RF 85mm F1.2L USM is designed for Canon R series mirrorless cameras and is the perfect full frame lens for portraits. With a fast f/1.2 aperture, this lens is superb in low light and is also great for \"bokeh\" as it includes 9 aperture blades." },
                new Product{ SupplierId = canon.Id, ProductCategoryId = lens.Id, Id = 3, Name = "Canon RF 16mm f2.8 STM", DefaultPrice = 379m, Currency = "EUR", Description = "The Canon RF 16mm f/2.8 STM is a compact wide-angle prime with a bright maximum aperture ideal for photographing architectural subjects and astrophotography scenes." },
                new Product{ SupplierId = canon.Id, ProductCategoryId = body.Id, Id = 4, Name = "Canon EOS R3", DefaultPrice = 6039m, Currency = "EUR", Description = "The EOS R3 Mirrorless Digital Camera is a fast-shooting all-in-one camera from Canon that equipped with new full-frame imaging technologies and improved AF performance for advanced amateurs and professionals." },
                new Product{ SupplierId = canon.Id, ProductCategoryId = body.Id, Id = 5, Name = "Canon EOS R6", DefaultPrice = 2139m, Currency = "EUR", Description = "The Canon EOS R6 is a versatile full-frame, weather-resistant mirrorless camera that's packed with advanced features for both photographers and videographers with 4K 60p video recording." },
                new Product{ SupplierId = canon.Id, ProductCategoryId = body.Id, Id = 6, Name = "Canon EOS RP", DefaultPrice = 899m, Currency = "EUR", Description = "Impressively small despite having a large full-frame sensor, the Canon EOS RP offers flexible imaging capabilities along with a portable form factor." },
                new Product{ SupplierId = nikon.Id, ProductCategoryId = lens.Id, Id = 7, Name = "Nikon NIKKOR Z 24mm f1.8 S", DefaultPrice = 719m, Currency = "EUR", Description = "The Nikon Z 24mm f/1.8 S is a wide prime lens for Nikon’s FX-format Z-series mirrorless cameras. This prime lens is ideal for architecture & landscape photography and with extensive weather sealing, you can use this lens in all conditions." },
                new Product{ SupplierId = nikon.Id, ProductCategoryId = lens.Id, Id = 8, Name = "Nikon NIKKOR Z 24-70mm f2.8 S", DefaultPrice = 1889m, Currency = "EUR", Description = "Bright and versatile, the NIKKOR Z 24-70mm f/2.8 S from Nikon is a workhorse standard zoom, covering wide-angle to portrait-length fields of view." },
                new Product{ SupplierId = nikon.Id, ProductCategoryId = lens.Id, Id = 9, Name = "Nikon NIKKOR Z 14-24mm f2.8 S", DefaultPrice = 1719m, Currency = "EUR", Description = "The NIKKOR Z 14-24mm f/2.8 S is an advanced optical designed ultra-wide-angle zoom lens. The large f/2.8 constant maximum aperture suits working in low-light conditions when shooting handheld and also offers improved depth of field control." },
                new Product{ SupplierId = nikon.Id, ProductCategoryId = body.Id, Id = 10, Name = "Nikon Z9", DefaultPrice = 6499m, Currency = "EUR", Description = "The Nikon Z9 flagship full-frame mirrorless camera is ideal for detail-oriented stills shooting as well as high resolution videos recording for professionals and shutterbugs." },
                new Product{ SupplierId = nikon.Id, ProductCategoryId = body.Id, Id = 11, Name = "Nikon Z7 II", DefaultPrice = 2599m, Currency = "EUR", Description = "The Nikon Z7 II is a lightweight, full-frame mirrorless camera with a high-resolution 45.7MP BSI CMOS sensor and dual EXPEED 6 image processors which offers superb speed and fast processing." },
                new Product{ SupplierId = nikon.Id, ProductCategoryId = body.Id, Id = 12, Name = "Nikon Z5", DefaultPrice = 1059m, Currency = "EUR", Description = "The latest in Nikon's Z series, the Nikon Z 5 is a tough, lightweight, weather-sealed & easy-to-use full-frame camera that is truly portable and is great for both still photography as well as 4K video shooting." },
                new Product{ SupplierId = sony.Id, ProductCategoryId = lens.Id, Id = 13, Name = "Sony FE 14mm f1.8 GM", DefaultPrice = 1339m, Currency = "EUR", Description = "A dynamic ultra wide-angle focal length with an especially bright design, the FE 14mm f/1.8 GM from Sony is a fast, versatile lens well-suited to landscape, nature, architectural, and astrophotography applications." },
                new Product{ SupplierId = sony.Id, ProductCategoryId = lens.Id, Id = 14, Name = "Sony FE 70-200mm f2.8 GM OSS II", DefaultPrice = 2699m, Currency = "EUR", Description = "The FE 70-200mm f/2.8 GM OSS II Lens is the latest large-aperture telephoto zoom G Master Lens from Sony upgraded from the previous model. With an advanced optical design, the unit affords phenomenal high resolution, along with smooth background defocus effects." },
                new Product{ SupplierId = sony.Id, ProductCategoryId = lens.Id, Id = 15, Name = "Sony FE 12-24mm f2.8 GM", DefaultPrice = 2359m, Currency = "EUR", Description = "Comprising a range of ultra-wide fields of view, the Sony FE 12-24mm f/2.8 GM is a bright and versatile zoom characterized by its broad range and bright design." },
                new Product{ SupplierId = sony.Id, ProductCategoryId = body.Id, Id = 16, Name = "Sony α a1", DefaultPrice = 5749m, Currency = "EUR", Description = "The Alpha 1 Mirrorless Digital Camera is a phenomenal all-in-one flagship full frame camera from Sony offers exceptionally high resolution still images and amazing 8K videos in a sophisticated designed compact body." },
                new Product{ SupplierId = sony.Id, ProductCategoryId = body.Id, Id = 17, Name = "Sony α a7R IV", DefaultPrice = 2499m, Currency = "EUR", Description = "This novel Alpha a7R IV (ILCE-7RM4A) Mirrorless Digital Camera from Sony is an upgrade version from the fourth edition of the a7R series and includes a high 2.35m-dot resolution 3-inch rear tilting touchscreen LCD and a SuperSpeed USB 5Gbps (USB 3.2) USB port with a 61MP Exmor R BSI CMOS sensor and enhanced BIONZ X image processor." },
                new Product{ SupplierId = sony.Id, ProductCategoryId = body.Id, Id = 18, Name = "Sony α a7C", DefaultPrice = 1699m, Currency = "EUR", Description = "The new Sony a7C body in black gives you full-frame pro-quality in a stylish, compact and lightweight design that is super portable. Features include a backside illuminated full-frame CMOS 24.2MP sensor, 4K movie recording, in-body 5-axis image stabilisation, fast real-time autofocus, ISO 100-51200 for great image quality, even in low-light conditions, 3-inch vari-angle touchscreen." }
            );
        }
    }
}
