using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendingMachine.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drinks",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drinks", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Drinks",
                columns: new[] { "ID", "Img", "Name", "Price", "Qty" },
                values: new object[] { 1, "https://img.fix-price.com/800x800/images/origin/origin/fc6260a7ec3553b7c06c8a599ce971c3.jpg", "Кока-кола", 100, 10 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drinks");
        }
    }
}
