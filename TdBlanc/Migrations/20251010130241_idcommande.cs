using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TdBlanc.Migrations
{
    /// <inheritdoc />
    public partial class idcommande : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "COM_IDCOMMANDE",
                schema: "public",
                table: "T_E_COMMANDE_COM",
                newName: "COM_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "COM_ID",
                schema: "public",
                table: "T_E_COMMANDE_COM",
                newName: "COM_IDCOMMANDE");
        }
    }
}
