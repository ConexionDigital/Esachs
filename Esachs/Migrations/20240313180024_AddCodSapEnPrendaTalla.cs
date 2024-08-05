using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Esachs.Migrations
{
    /// <inheritdoc />
    public partial class AddCodSapEnPrendaTalla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CodSAP",
                table: "PrendasTallas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodSAP",
                table: "PrendasTallas");
        }
    }
}
