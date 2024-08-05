using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Esachs.Migrations
{
    /// <inheritdoc />
    public partial class CecoIdsNuevas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "COM_ID",
                table: "Ceco",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CONT_ID",
                table: "Ceco",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "REG_ID",
                table: "Ceco",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "COM_ID",
                table: "Ceco");

            migrationBuilder.DropColumn(
                name: "CONT_ID",
                table: "Ceco");

            migrationBuilder.DropColumn(
                name: "REG_ID",
                table: "Ceco");
        }
    }
}
