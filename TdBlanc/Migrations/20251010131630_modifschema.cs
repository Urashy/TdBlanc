using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TdBlanc.Migrations
{
    /// <inheritdoc />
    public partial class modifschema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Controle");

            migrationBuilder.RenameTable(
                name: "T_E_UTILISATEUR_UTI",
                schema: "public",
                newName: "T_E_UTILISATEUR_UTI",
                newSchema: "Controle");

            migrationBuilder.RenameTable(
                name: "T_E_COMMANDE_COM",
                schema: "public",
                newName: "T_E_COMMANDE_COM",
                newSchema: "Controle");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.RenameTable(
                name: "T_E_UTILISATEUR_UTI",
                schema: "Controle",
                newName: "T_E_UTILISATEUR_UTI",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "T_E_COMMANDE_COM",
                schema: "Controle",
                newName: "T_E_COMMANDE_COM",
                newSchema: "public");
        }
    }
}
