using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace minha_agenda_minha_vida.Migrations
{
    public partial class InitialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agendas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titulo = table.Column<string>(type: "TEXT", nullable: true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendas", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Agendas",
                columns: new[] { "Id", "Data", "Descricao", "Titulo" },
                values: new object[] { 1, new DateTime(2020, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reuniao com a Marilene", "Reunião" });

            migrationBuilder.InsertData(
                table: "Agendas",
                columns: new[] { "Id", "Data", "Descricao", "Titulo" },
                values: new object[] { 2, new DateTime(2020, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reuniao com a Julia", "Reunião" });

            migrationBuilder.InsertData(
                table: "Agendas",
                columns: new[] { "Id", "Data", "Descricao", "Titulo" },
                values: new object[] { 3, new DateTime(2020, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reuniao com a Thais", "Reunião" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendas");
        }
    }
}
