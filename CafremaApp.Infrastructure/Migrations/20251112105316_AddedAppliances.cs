using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CafremaApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedAppliances : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Inventories",
                type: "character varying(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Manufacturer",
                table: "Inventories",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Inventories",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "Manufacturer",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "Inventories");
        }
    }
}
