using Microsoft.EntityFrameworkCore.Migrations;

namespace Codecool.CodecoolShop.Migrations
{
    public partial class InitialDBCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Department = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Currency = table.Column<string>(nullable: true),
                    DefaultPrice = table.Column<decimal>(type: "decimal(20,2)", nullable: false),
                    ProductCategoryId = table.Column<int>(nullable: true),
                    SupplierId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Category_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Department", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Camera Lens", "Quality lenses from the top Camera manufacturers.", "Lens" },
                    { 2, "Camera Body", "Top of the line Mirrorless digital camera bodies.", "Body" }
                });

            migrationBuilder.InsertData(
                table: "Supplier",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Canon Inc. (キヤノンキャノン株式会社) is a Japanese multinational corporation headquartered in Ōta, Tokyo, Japan, specializing in optical, imaging, and industrial products, such as lenses, cameras, medical equipment, scanners, printers, and semiconductor manufacturing equipment.", "Canon" },
                    { 2, "Nikon Corporation (株式会社ニコン), also known just as Nikon, is a Japanese multinational corporation headquartered in Tokyo, Japan, specializing in optics and imaging products. The companies held by Nikon form the Nikon Group.", "Nikon" },
                    { 3, "Sony Group Corporation (ソニーグループ株式会社), commonly known as Sony and stylized as SONY, is a Japanese multinational conglomerate corporation headquartered in Kōnan, Minato, Tokyo, Japan.", "Sony" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Currency", "DefaultPrice", "Description", "Name", "ProductCategoryId", "SupplierId" },
                values: new object[,]
                {
                    { 1, "EUR", 1849m, "The Canon RF 15-35mm f/2.8 is a full-frame pro wide-angle zoom lens offering superior performance thanks to a Nano USM motor, 5-stops of image stabilisation plus 3 Aspherical and 2 UD elements for stunning sharpness.", "Canon RF 15-35mm f2.8 L IS USM", 1, 1 },
                    { 16, "EUR", 5749m, "The Alpha 1 Mirrorless Digital Camera is a phenomenal all-in-one flagship full frame camera from Sony offers exceptionally high resolution still images and amazing 8K videos in a sophisticated designed compact body.", "Sony α a1", 2, 3 },
                    { 15, "EUR", 2359m, "Comprising a range of ultra-wide fields of view, the Sony FE 12-24mm f/2.8 GM is a bright and versatile zoom characterized by its broad range and bright design.", "Sony FE 12-24mm f2.8 GM", 1, 3 },
                    { 14, "EUR", 2699m, "The FE 70-200mm f/2.8 GM OSS II Lens is the latest large-aperture telephoto zoom G Master Lens from Sony upgraded from the previous model. With an advanced optical design, the unit affords phenomenal high resolution, along with smooth background defocus effects.", "Sony FE 70-200mm f2.8 GM OSS II", 1, 3 },
                    { 13, "EUR", 1339m, "A dynamic ultra wide-angle focal length with an especially bright design, the FE 14mm f/1.8 GM from Sony is a fast, versatile lens well-suited to landscape, nature, architectural, and astrophotography applications.", "Sony FE 14mm f1.8 GM", 1, 3 },
                    { 12, "EUR", 1059m, "The latest in Nikon's Z series, the Nikon Z 5 is a tough, lightweight, weather-sealed & easy-to-use full-frame camera that is truly portable and is great for both still photography as well as 4K video shooting.", "Nikon Z5", 2, 2 },
                    { 11, "EUR", 2599m, "The Nikon Z7 II is a lightweight, full-frame mirrorless camera with a high-resolution 45.7MP BSI CMOS sensor and dual EXPEED 6 image processors which offers superb speed and fast processing.", "Nikon Z7 II", 2, 2 },
                    { 10, "EUR", 6499m, "The Nikon Z9 flagship full-frame mirrorless camera is ideal for detail-oriented stills shooting as well as high resolution videos recording for professionals and shutterbugs.", "Nikon Z9", 2, 2 },
                    { 9, "EUR", 1719m, "The NIKKOR Z 14-24mm f/2.8 S is an advanced optical designed ultra-wide-angle zoom lens. The large f/2.8 constant maximum aperture suits working in low-light conditions when shooting handheld and also offers improved depth of field control.", "Nikon NIKKOR Z 14-24mm f2.8 S", 1, 2 },
                    { 8, "EUR", 1889m, "Bright and versatile, the NIKKOR Z 24-70mm f/2.8 S from Nikon is a workhorse standard zoom, covering wide-angle to portrait-length fields of view.", "Nikon NIKKOR Z 24-70mm f2.8 S", 1, 2 },
                    { 7, "EUR", 719m, "The Nikon Z 24mm f/1.8 S is a wide prime lens for Nikon’s FX-format Z-series mirrorless cameras. This prime lens is ideal for architecture & landscape photography and with extensive weather sealing, you can use this lens in all conditions.", "Nikon NIKKOR Z 24mm f1.8 S", 1, 2 },
                    { 6, "EUR", 899m, "Impressively small despite having a large full-frame sensor, the Canon EOS RP offers flexible imaging capabilities along with a portable form factor.", "Canon EOS RP", 2, 1 },
                    { 5, "EUR", 2139m, "The Canon EOS R6 is a versatile full-frame, weather-resistant mirrorless camera that's packed with advanced features for both photographers and videographers with 4K 60p video recording.", "Canon EOS R6", 2, 1 },
                    { 4, "EUR", 6039m, "The EOS R3 Mirrorless Digital Camera is a fast-shooting all-in-one camera from Canon that equipped with new full-frame imaging technologies and improved AF performance for advanced amateurs and professionals.", "Canon EOS R3", 2, 1 },
                    { 3, "EUR", 379m, "The Canon RF 16mm f/2.8 STM is a compact wide-angle prime with a bright maximum aperture ideal for photographing architectural subjects and astrophotography scenes.", "Canon RF 16mm f2.8 STM", 1, 1 },
                    { 2, "EUR", 2349m, "The Canon RF 85mm F1.2L USM is designed for Canon R series mirrorless cameras and is the perfect full frame lens for portraits. With a fast f/1.2 aperture, this lens is superb in low light and is also great for \"bokeh\" as it includes 9 aperture blades.", "Canon RF 85mm f1.2 L IS USM", 1, 1 },
                    { 17, "EUR", 2499m, "This novel Alpha a7R IV (ILCE-7RM4A) Mirrorless Digital Camera from Sony is an upgrade version from the fourth edition of the a7R series and includes a high 2.35m-dot resolution 3-inch rear tilting touchscreen LCD and a SuperSpeed USB 5Gbps (USB 3.2) USB port with a 61MP Exmor R BSI CMOS sensor and enhanced BIONZ X image processor.", "Sony α a7R IV", 2, 3 },
                    { 18, "EUR", 1699m, "The new Sony a7C body in black gives you full-frame pro-quality in a stylish, compact and lightweight design that is super portable. Features include a backside illuminated full-frame CMOS 24.2MP sensor, 4K movie recording, in-body 5-axis image stabilisation, fast real-time autofocus, ISO 100-51200 for great image quality, even in low-light conditions, 3-inch vari-angle touchscreen.", "Sony α a7C", 2, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductCategoryId",
                table: "Product",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_SupplierId",
                table: "Product",
                column: "SupplierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Supplier");
        }
    }
}
