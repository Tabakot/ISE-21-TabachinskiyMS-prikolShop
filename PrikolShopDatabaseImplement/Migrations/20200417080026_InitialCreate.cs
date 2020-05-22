using Microsoft.EntityFrameworkCore.Migrations;

namespace PrikolShopDatabaseImplement.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boxes_Gifts_GiftId",
                table: "Boxes");

            migrationBuilder.DropColumn(
                name: "BoxId",
                table: "Boxes");

            migrationBuilder.AlterColumn<int>(
                name: "GiftId",
                table: "Boxes",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_GiftBoxId",
                table: "Orders",
                column: "GiftBoxId");

            migrationBuilder.AddForeignKey(
                name: "FK_Boxes_Gifts_GiftId",
                table: "Boxes",
                column: "GiftId",
                principalTable: "Gifts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_GiftBoxes_GiftBoxId",
                table: "Orders",
                column: "GiftBoxId",
                principalTable: "GiftBoxes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boxes_Gifts_GiftId",
                table: "Boxes");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_GiftBoxes_GiftBoxId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_GiftBoxId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "GiftId",
                table: "Boxes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "BoxId",
                table: "Boxes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Boxes_Gifts_GiftId",
                table: "Boxes",
                column: "GiftId",
                principalTable: "Gifts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
