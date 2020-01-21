using Microsoft.EntityFrameworkCore.Migrations;

namespace restful_api.Migrations
{
    public partial class FixingDeliveryAddressForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryAddresses_DeliveryAddresses_delivery_id",
                table: "DeliveryAddresses");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryAddresses_delivery_id",
                table: "DeliveryAddresses");

            migrationBuilder.DropColumn(
                name: "delivery_id",
                table: "DeliveryAddresses");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_delivery_id",
                table: "Orders",
                column: "delivery_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_DeliveryAddresses_delivery_id",
                table: "Orders",
                column: "delivery_id",
                principalTable: "DeliveryAddresses",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_DeliveryAddresses_delivery_id",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_delivery_id",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "delivery_id",
                table: "DeliveryAddresses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryAddresses_delivery_id",
                table: "DeliveryAddresses",
                column: "delivery_id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryAddresses_DeliveryAddresses_delivery_id",
                table: "DeliveryAddresses",
                column: "delivery_id",
                principalTable: "DeliveryAddresses",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
