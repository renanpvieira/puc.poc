using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace puc.poc.modulo.agenda.repositorio.writemodel.Migrations
{
    public partial class MigracaoInicial : Migration
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
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Associados", x => x.UniqueId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Conveniados",
                columns: table => new
                {
                    UniqueId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conveniados", x => x.UniqueId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EspecialidadesConveniado",
                columns: table => new
                {
                    UniqueId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TempoDuracao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EspecialidadesConveniado", x => x.UniqueId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Agendamentos",
                columns: table => new
                {
                    UniqueId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataHoraInicio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataHoraFim = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AssociadoUniqueId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConveniadoUniqueId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EspecialidadeUniqueId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendamentos", x => x.UniqueId);
                    table.ForeignKey(
                        name: "FK_Agendamentos_Associados_AssociadoUniqueId",
                        column: x => x.AssociadoUniqueId,
                        principalTable: "Associados",
                        principalColumn: "UniqueId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Agendamentos_Conveniados_ConveniadoUniqueId",
                        column: x => x.ConveniadoUniqueId,
                        principalTable: "Conveniados",
                        principalColumn: "UniqueId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Agendamentos_EspecialidadesConveniado_EspecialidadeUniqueId",
                        column: x => x.EspecialidadeUniqueId,
                        principalTable: "EspecialidadesConveniado",
                        principalColumn: "UniqueId",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_AssociadoUniqueId",
                table: "Agendamentos",
                column: "AssociadoUniqueId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_ConveniadoUniqueId",
                table: "Agendamentos",
                column: "ConveniadoUniqueId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_EspecialidadeUniqueId",
                table: "Agendamentos",
                column: "EspecialidadeUniqueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendamentos");

            migrationBuilder.DropTable(
                name: "Associados");

            migrationBuilder.DropTable(
                name: "Conveniados");

            migrationBuilder.DropTable(
                name: "EspecialidadesConveniado");
        }
    }
}
