using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CafremaApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RoomRelationsAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Rooms_RoomId",
                table: "Inventories");

            migrationBuilder.AlterColumn<Guid>(
                name: "RoomId",
                table: "Inventories",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Rooms_RoomId",
                table: "Inventories",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Rooms_RoomId",
                table: "Inventories");

            migrationBuilder.AlterColumn<Guid>(
                name: "RoomId",
                table: "Inventories",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Rooms_RoomId",
                table: "Inventories",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
