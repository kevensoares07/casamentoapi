using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiMatheus.Migrations
{
    /// <inheritdoc />
    public partial class RemovendoÃtudo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PresentesSelecionados");

            migrationBuilder.DropTable(
                name: "PresentesEsperados");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Presentes");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Presentes",
                newName: "PessoaConfirmada");

            migrationBuilder.AddColumn<bool>(
                name: "Confirmado",
                table: "Presentes",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Presentes",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Confirmado",
                table: "Presentes");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Presentes");

            migrationBuilder.RenameColumn(
                name: "PessoaConfirmada",
                table: "Presentes",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Presentes",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PresentesEsperados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresentesEsperados", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PresentesSelecionados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PresenteEsperadoId = table.Column<int>(type: "int", nullable: false),
                    PresenteId = table.Column<int>(type: "int", nullable: false),
                    Pessoa = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresentesSelecionados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PresentesSelecionados_PresentesEsperados_PresenteEsperadoId",
                        column: x => x.PresenteEsperadoId,
                        principalTable: "PresentesEsperados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PresentesSelecionados_Presentes_PresenteId",
                        column: x => x.PresenteId,
                        principalTable: "Presentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PresentesSelecionados_PresenteEsperadoId",
                table: "PresentesSelecionados",
                column: "PresenteEsperadoId");

            migrationBuilder.CreateIndex(
                name: "IX_PresentesSelecionados_PresenteId",
                table: "PresentesSelecionados",
                column: "PresenteId");
        }
    }
}
