using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Farmax.Migrations
{
    /// <inheritdoc />
    public partial class produtos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descrição",
                table: "produtos",
                newName: "Descricao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "produtos",
                newName: "Descrição");
        }
    }
}
