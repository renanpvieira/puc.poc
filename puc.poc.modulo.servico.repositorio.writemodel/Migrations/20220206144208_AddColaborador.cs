using Microsoft.EntityFrameworkCore.Migrations;

namespace puc.poc.modulo.servico.repositorio.writemodel.Migrations
{
    public partial class AddColaborador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ColaboradorUniqueId",
                table: "OrdensServico",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Colaboradores",
                columns: table => new
                {
                    UniqueId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaboradores", x => x.UniqueId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_OrdensServico_ColaboradorUniqueId",
                table: "OrdensServico",
                column: "ColaboradorUniqueId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdensServico_Colaboradores_ColaboradorUniqueId",
                table: "OrdensServico",
                column: "ColaboradorUniqueId",
                principalTable: "Colaboradores",
                principalColumn: "UniqueId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdensServico_Colaboradores_ColaboradorUniqueId",
                table: "OrdensServico");

            migrationBuilder.DropTable(
                name: "Colaboradores");

            migrationBuilder.DropIndex(
                name: "IX_OrdensServico_ColaboradorUniqueId",
                table: "OrdensServico");

            migrationBuilder.DropColumn(
                name: "ColaboradorUniqueId",
                table: "OrdensServico");
        }
    }
}
