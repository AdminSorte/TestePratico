using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MinhaAgenda.Data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agendas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "varchar(100)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(500)", nullable: false),
                    DataAgedamento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendas", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Agendas",
                columns: new[] { "Id", "DataAgedamento", "Descricao", "Titulo" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 5, 9, 21, 17, 9, 380, DateTimeKind.Local).AddTicks(91), "So deus Saber...", "Será se vou Passar?" },
                    { 2, new DateTime(2021, 5, 9, 21, 17, 9, 380, DateTimeKind.Local).AddTicks(8211), "hummmm", "Sorte Online" },
                    { 3, new DateTime(2021, 5, 9, 21, 17, 9, 380, DateTimeKind.Local).AddTicks(8223), "hummmm", "Sei não viu..." },
                    { 4, new DateTime(2021, 5, 9, 21, 17, 9, 380, DateTimeKind.Local).AddTicks(8225), "Vou Joga na mega Sena qualquer coisa...", "Então Beleza,Boa Segunda-Feira" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendas");
        }
    }
}
