using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiFinancas.Migrations
{
    /// <inheritdoc />
    public partial class categoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contas_Categorias_CategoriaContaId",
                table: "Contas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categorias",
                table: "Categorias");

            migrationBuilder.RenameTable(
                name: "Categorias",
                newName: "CategoriasConta");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoriasConta",
                table: "CategoriasConta",
                column: "CategoriaContaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contas_CategoriasConta_CategoriaContaId",
                table: "Contas",
                column: "CategoriaContaId",
                principalTable: "CategoriasConta",
                principalColumn: "CategoriaContaId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contas_CategoriasConta_CategoriaContaId",
                table: "Contas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoriasConta",
                table: "CategoriasConta");

            migrationBuilder.RenameTable(
                name: "CategoriasConta",
                newName: "Categorias");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categorias",
                table: "Categorias",
                column: "CategoriaContaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contas_Categorias_CategoriaContaId",
                table: "Contas",
                column: "CategoriaContaId",
                principalTable: "Categorias",
                principalColumn: "CategoriaContaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
