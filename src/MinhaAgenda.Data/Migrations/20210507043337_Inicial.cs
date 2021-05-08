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
