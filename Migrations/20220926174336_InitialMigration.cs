using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraphQL_ASPNET_API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseYear = table.Column<int>(type: "int", nullable: false),
                    HorsePower = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Country", "Name" },
                values: new object[,]
                {
                    { 1, "Germany", "BMW" },
                    { 2, "USA", "Tesla" },
                    { 3, "Germany", "Volkswagen" },
                    { 4, "Germany", "Porsche" },
                    { 5, "France", "Citroen" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BrandId", "HorsePower", "ImageUrl", "Model", "ReleaseYear" },
                values: new object[,]
                {
                    { 1, 1, 350, "https://imgd.aeplcdn.com/1056x594/n/cw/ec/50723/m5-exterior-rear-view.jpeg", "M5", 2020 },
                    { 2, 1, 400, "https://imgd.aeplcdn.com/1056x594/cw/ec/28286/BMW-X7-Rear-view-145752.jpg", "X7", 2022 },
                    { 3, 2, 500, "https://imgd.aeplcdn.com/1056x594/n/cw/ec/93821/exterior-right-front-three-quarter.jpeg", "Model S", 2019 },
                    { 4, 3, 300, "https://imgd.aeplcdn.com/1056x594/n/cw/ec/53123/tiguan-exterior-left-front-three-quarter.jpeg", "Tiguan", 2019 },
                    { 5, 4, 400, "https://imgd.aeplcdn.com/1056x594/n/cw/ec/32951/cayenne-exterior-right-rear-three-quarter.jpeg", "Cayenne", 2018 },
                    { 6, 4, 700, "https://imgd.aeplcdn.com/1056x594/n/cw/ec/45063/porsche-taycan-right-rear-three-quarter0.jpeg", "Taycan", 2022 },
                    { 7, 5, 200, "https://imgd.aeplcdn.com/1056x594/n/cw/ec/103611/c3-exterior-left-rear-three-quarter.jpeg", "C3", 2015 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_BrandId",
                table: "Cars",
                column: "BrandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
