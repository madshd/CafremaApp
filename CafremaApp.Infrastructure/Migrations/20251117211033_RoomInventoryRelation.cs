using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CafremaApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RoomInventoryRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RoomId",
                table: "Inventories",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_RoomId",
                table: "Inventories",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Rooms_RoomId",
                table: "Inventories",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Rooms_RoomId",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_RoomId",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Inventories");
        }
    }
}
