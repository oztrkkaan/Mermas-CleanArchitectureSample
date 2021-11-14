using Microsoft.EntityFrameworkCore.Migrations;

namespace Mermas.Persistence.Migrations
{
    public partial class UpdateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MinProductStockQuantity",
                table: "Categories",
                newName: "ProductMinStockQuantity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductMinStockQuantity",
                table: "Categories",
                newName: "MinProductStockQuantity");
        }
    }
}
