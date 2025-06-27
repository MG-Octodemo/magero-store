using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace magero_store.Migrations
{
    /// <inheritdoc />
    public partial class AddColorToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    Color = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Negro", "High-performance gaming laptop with RTX 3080", "https://images.unsplash.com/photo-1603302576837-37561b2e2302", "Gaming Laptop", 1999.99m },
                    { 2, "Blanco", "Premium wireless earbuds with noise cancellation", "https://images.unsplash.com/photo-1590658087412-d1d9f559ef20", "Wireless Earbuds", 199.99m },
                    { 3, "Negro", "32-inch 4K HDR Professional Monitor", "https://images.unsplash.com/photo-1527443224154-c4a3942d3acf", "4K Monitor", 699.99m },
                    { 4, "Negro", "RGB Mechanical Gaming Keyboard", "https://images.unsplash.com/photo-1595225476474-87563907a212", "Mechanical Keyboard", 159.99m },
                    { 5, "Negro", "Wireless Gaming Mouse with 25K DPI", "https://images.unsplash.com/photo-1527864550417-7fd91fc51a46", "Gaming Mouse", 129.99m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
