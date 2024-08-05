using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Esachs.Migrations
{
    /// <inheritdoc />
    public partial class AddColPrendas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "Prendas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Proveedor",
                table: "Prendas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "Prendas");

            migrationBuilder.DropColumn(
                name: "Proveedor",
                table: "Prendas");
        }
    }
}
