using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiFinancas.Migrations
{
    /// <inheritdoc />
    public partial class TitleAcount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NomeConta",
                table: "Contas",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeConta",
                table: "Contas");
        }
    }
}
