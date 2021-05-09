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
                    { 1, new DateTime(2021, 5, 9, 18, 22, 53, 336, DateTimeKind.Local).AddTicks(3170), "So deus Saber...", "Sera se vou Passar?" },
                    { 2, new DateTime(2021, 5, 9, 18, 22, 53, 337, DateTimeKind.Local).AddTicks(1021), "hummmm", "Sorte Online" },
                    { 3, new DateTime(2021, 5, 9, 18, 22, 53, 337, DateTimeKind.Local).AddTicks(1033), "hummmm", "Sei não viu..." },
                    { 4, new DateTime(2021, 5, 9, 18, 22, 53, 337, DateTimeKind.Local).AddTicks(1035), "Vou Joga na mega Sena qualquer coisa...", "Então Beleza,Boa Segunda-Feira!" }
                });

            migrationBuilder.Sql(@"CREATE  PROCEDURE AtualizarAgenda
                @Id int,@Titulo Varchar(100),@Descricao varchar(500),@DataAgedamento Datetime2
                AS
                BEGIN
                    UPDATE Agendas
					set Titulo = @Titulo ,Descricao = @Descricao , DataAgedamento =@DataAgedamento
					Where id = @ID
                END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendas");

            migrationBuilder.Sql(@"DROP PROCEDURE AtualizarAgenda");
        }
    }
}
