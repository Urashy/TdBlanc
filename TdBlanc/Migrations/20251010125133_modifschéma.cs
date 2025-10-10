using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TdBlanc.Migrations
{
    /// <inheritdoc />
    public partial class modifschéma : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Public");

            migrationBuilder.RenameTable(
                name: "T_E_UTILISATEUR_UTI",
                newName: "T_E_UTILISATEUR_UTI",
                newSchema: "Public");

            migrationBuilder.RenameTable(
                name: "T_E_COMMANDE_COM",
                newName: "T_E_COMMANDE_COM",
                newSchema: "Public");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "T_E_UTILISATEUR_UTI",
                schema: "Public",
                newName: "T_E_UTILISATEUR_UTI");

            migrationBuilder.RenameTable(
                name: "T_E_COMMANDE_COM",
                schema: "Public",
                newName: "T_E_COMMANDE_COM");
        }
    }
}
