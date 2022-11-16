using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Db.Context.Migrations
{
    public partial class fixBaseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_users_Uid",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_orders_Uid",
                table: "orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_users_Uid",
                table: "users",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_orders_Uid",
                table: "orders",
                column: "Uid",
                unique: true);
        }
    }
}
