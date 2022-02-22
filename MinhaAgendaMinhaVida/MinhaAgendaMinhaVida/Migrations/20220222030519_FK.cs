using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinhaAgendaMinhaVida.Migrations
{
    public partial class FK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agend_Usuario",
                table: "Agendamentos");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Agend",
                table: "Agendamentos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Agend",
                table: "Agendamentos");

            migrationBuilder.AddForeignKey(
                name: "FK_Agend_Usuario",
                table: "Agendamentos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }
    }
}
