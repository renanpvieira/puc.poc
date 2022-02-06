using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace puc.poc.modulo.servico.repositorio.writemodel.Migrations
{
    public partial class InicialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Associados",
                columns: table => new
                {
                    UniqueId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoPlano = table.Column<int>(type: "int", nullable: false),
                    ModeloPlano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Associados", x => x.UniqueId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    UniqueId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descricao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ValorPago = table.Column<double>(type: "double", nullable: false),
                    ValorCobrado = table.Column<double>(type: "double", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.UniqueId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OrdensServico",
                columns: table => new
                {
                    UniqueId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataServico = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AssociadoUniqueId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ServicoUniqueId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdensServico", x => x.UniqueId);
                    table.ForeignKey(
                        name: "FK_OrdensServico_Associados_AssociadoUniqueId",
                        column: x => x.AssociadoUniqueId,
                        principalTable: "Associados",
                        principalColumn: "UniqueId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdensServico_Servicos_ServicoUniqueId",
                        column: x => x.ServicoUniqueId,
                        principalTable: "Servicos",
                        principalColumn: "UniqueId",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_OrdensServico_AssociadoUniqueId",
                table: "OrdensServico",
                column: "AssociadoUniqueId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdensServico_ServicoUniqueId",
                table: "OrdensServico",
                column: "ServicoUniqueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdensServico");

            migrationBuilder.DropTable(
                name: "Associados");

            migrationBuilder.DropTable(
                name: "Servicos");
        }
    }
}
