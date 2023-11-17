using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantFaves.Migrations
{
    public partial class initialization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    restaurant = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rating = table.Column<int>(type: "int", nullable: false),
                    orderAgain = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "id", "description", "orderAgain", "rating", "restaurant" },
                values: new object[,]
                {
                    { 1, "Whole Grain Tuscan Fresca", true, 4, "Olive Garden" },
                    { 2, "McChicken", false, 3, "McDonalds" },
                    { 3, "Lobster Thermidor", true, 5, "Red Lobster" },
                    { 4, "Mac & Cheese", false, 2, "Olive Garden" },
                    { 5, "Big Mac", true, 4, "McDonalds" },
                    { 6, "Oysters", false, 3, "Red Lobster" },
                    { 7, "Spaghetti", true, 5, "Olive Garden" },
                    { 8, "McSalad", false, 1, "McDonalds" },
                    { 9, "Shrimp Alfredo", true, 4, "Red Lobster" },
                    { 10, "Breadsticks", false, 3, "Olive Garden" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
