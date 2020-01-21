using Microsoft.EntityFrameworkCore.Migrations;

namespace restful_api.Migrations
{
    public partial class AddForeignKeyinEachTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "delivery_id",
                table: "DeliveryAddresses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_cat_id",
                table: "Products",
                column: "cat_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_customer_id",
                table: "Orders",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_order_id",
                table: "OrderItems",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_product_id",
                table: "OrderItems",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Logins_customer_id",
                table: "Logins",
                column: "customer_id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Logins_Customers_customer_id",
                table: "Logins",
                column: "customer_id",
                principalTable: "Customers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_order_id",
                table: "OrderItems",
                column: "order_id",
                principalTable: "Orders",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Products_product_id",
                table: "OrderItems",
                column: "product_id",
                principalTable: "Products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_customer_id",
                table: "Orders",
                column: "customer_id",
                principalTable: "Customers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_cat_id",
                table: "Products",
                column: "cat_id",
                principalTable: "Categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryAddresses_DeliveryAddresses_delivery_id",
                table: "DeliveryAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Logins_Customers_customer_id",
                table: "Logins");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_order_id",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Products_product_id",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_customer_id",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_cat_id",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_cat_id",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Orders_customer_id",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_order_id",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_product_id",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_Logins_customer_id",
                table: "Logins");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryAddresses_delivery_id",
                table: "DeliveryAddresses");

            migrationBuilder.DropColumn(
                name: "delivery_id",
                table: "DeliveryAddresses");
        }
    }
}
