using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinhaAgendaMinhaVida.Migrations
{
    public partial class SeedUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(table: "Usuarios", columns: new[] { "Login", "Senha" }, values: new object[] { "admin", "601f1889667efaebb33b8c12572835da3f027f78" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
