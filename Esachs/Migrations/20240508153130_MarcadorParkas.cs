using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Esachs.Migrations
{
    /// <inheritdoc />
    public partial class MarcadorParkas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ParkaSolicitada",
                table: "Funcionarios",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParkaSolicitada",
                table: "Funcionarios");
        }
    }
}
