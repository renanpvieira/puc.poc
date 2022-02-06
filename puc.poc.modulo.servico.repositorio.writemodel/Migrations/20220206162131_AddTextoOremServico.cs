using Microsoft.EntityFrameworkCore.Migrations;

namespace puc.poc.modulo.servico.repositorio.writemodel.Migrations
{
    public partial class AddTextoOremServico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Texto",
                table: "OrdensServico",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Texto",
                table: "OrdensServico");
        }
    }
}
