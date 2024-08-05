using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Esachs.Migrations
{
    /// <inheritdoc />
    public partial class CecoCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Sexo",
                table: "PrendasTallas",
                type: "nvarchar(1)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CecoId",
                table: "Funcionarios",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Ceco",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
