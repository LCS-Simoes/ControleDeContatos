using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDeContatos.Migrations
{
    /// <inheritdoc />
    public partial class CriandoVinculoUsuarioNaContato : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioID",
                table: "Contato",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contato_UsuarioID",
                table: "Contato",
                column: "UsuarioID");

            migrationBuilder.AddForeignKey(
                name: "FK_Contato_Usuarios_UsuarioID",
                table: "Contato",
                column: "UsuarioID",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contato_Usuarios_UsuarioID",
                table: "Contato");

            migrationBuilder.DropIndex(
                name: "IX_Contato_UsuarioID",
                table: "Contato");

            migrationBuilder.DropColumn(
                name: "UsuarioID",
                table: "Contato");
        }
    }
}
