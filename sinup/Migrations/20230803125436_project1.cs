using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjectTWO.Migrations
{
    /// <inheritdoc />
    public partial class project1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    ProdId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    ProdCat = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.ProdId);
                });

            migrationBuilder.CreateTable(
                name: "selings_products",
                columns: table => new
                {
                    prodID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProdName = table.Column<string>(type: "text", nullable: false),
                    ProdPrice = table.Column<int>(type: "integer", nullable: false),
                    ProdQty = table.Column<int>(type: "integer", nullable: false),
                    Total = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_selings_products", x => x.prodID);
                });

            migrationBuilder.CreateTable(
                name: "sellers",
                columns: table => new
                {
                    SellerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sellers", x => x.SellerId);
                });

            migrationBuilder.CreateTable(
                name: "serviceModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_serviceModels", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Dairy products", "Sut" },
                    { 2, "Non mahsulotlari", "Non" },
                    { 3, "Ichimliklar turli hil", "Ichimliklar" }
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "ProdId", "Name", "Price", "ProdCat", "Quantity" },
                values: new object[,]
                {
                    { 1, "Non", 20, "Non", 3500 },
                    { 2, "Bolichka", 20, "Non", 8000 },
                    { 3, "Pitsa", 3, "Non", 30000 },
                    { 4, "Coca-cola", 10, "Ichimliklar", 11900 },
                    { 5, "Pepsi", 10, "Ichimliklar", 11900 },
                    { 6, "Fanta", 10, "Ichimliklar", 11900 },
                    { 7, "Sgushenka", 10, "Sut", 28990 },
                    { 8, "Qaymoq", 10, "Sut", 13900 },
                    { 9, "Sut", 10, "Sut", 10990 }
                });

            migrationBuilder.InsertData(
                table: "sellers",
                columns: new[] { "SellerId", "Age", "Name", "Password", "Phone" },
                values: new object[] { 1, 21, "Sarvar", "sarvar0303", "+998 950940303" });

            migrationBuilder.InsertData(
                table: "serviceModels",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "Phone", "UserName" },
                values: new object[] { 1, "G'ulomjonov", "Sarvar", "sarvar0303", "+998 950940303", "murodovich" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "selings_products");

            migrationBuilder.DropTable(
                name: "sellers");

            migrationBuilder.DropTable(
                name: "serviceModels");
        }
    }
}
