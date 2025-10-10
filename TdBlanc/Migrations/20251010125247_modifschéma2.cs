using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TdBlanc.Migrations
{
    /// <inheritdoc />
    public partial class modifschéma2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.RenameTable(
                name: "T_E_UTILISATEUR_UTI",
                schema: "Public",
                newName: "T_E_UTILISATEUR_UTI",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "T_E_COMMANDE_COM",
                schema: "Public",
                newName: "T_E_COMMANDE_COM",
                newSchema: "public");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Public");

            migrationBuilder.RenameTable(
                name: "T_E_UTILISATEUR_UTI",
                schema: "public",
                newName: "T_E_UTILISATEUR_UTI",
                newSchema: "Public");

            migrationBuilder.RenameTable(
                name: "T_E_COMMANDE_COM",
                schema: "public",
                newName: "T_E_COMMANDE_COM",
                newSchema: "Public");
        }
    }
}
