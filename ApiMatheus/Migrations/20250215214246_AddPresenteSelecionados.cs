using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiMatheus.Migrations
{
    /// <inheritdoc />
    public partial class AddPresenteSelecionados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PresentesSelecionados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PresenteId = table.Column<int>(type: "int", nullable: false),
                    PresenteEsperadoId = table.Column<int>(type: "int", nullable: false)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PresentesSelecionados");
        }
    }
}
