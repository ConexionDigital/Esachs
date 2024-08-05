using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Esachs.Migrations
{
    /// <inheritdoc />
    public partial class CecoDrop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Ceco_CecoId",
                table: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Ceco");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_CecoId",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "CecoId",
                table: "Funcionarios");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CecoId",
                table: "Funcionarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Ceco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ceco", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_CecoId",
                table: "Funcionarios",
                column: "CecoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Ceco_CecoId",
                table: "Funcionarios",
                column: "CecoId",
                principalTable: "Ceco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
