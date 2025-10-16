using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaFinanceiro.Migrations
{
    /// <inheritdoc />
    public partial class adicionando_atributo_endereco_cliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataAberturaa",
                table: "Conta",
                newName: "DataAbertura");

            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "Cliente",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "Cliente");

            migrationBuilder.RenameColumn(
                name: "DataAbertura",
                table: "Conta",
                newName: "DataAberturaa");
        }
    }
}
