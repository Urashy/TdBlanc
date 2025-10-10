using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TdBlanc.Migrations
{
    /// <inheritdoc />
    public partial class modiffkucommande : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdMarque",
                schema: "public",
                table: "T_E_COMMANDE_COM",
                newName: "UTI_ID");

            migrationBuilder.RenameIndex(
                name: "IX_T_E_COMMANDE_COM_IdMarque",
                schema: "public",
                table: "T_E_COMMANDE_COM",
                newName: "IX_T_E_COMMANDE_COM_UTI_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UTI_ID",
                schema: "public",
                table: "T_E_COMMANDE_COM",
                newName: "IdMarque");

            migrationBuilder.RenameIndex(
                name: "IX_T_E_COMMANDE_COM_UTI_ID",
                schema: "public",
                table: "T_E_COMMANDE_COM",
                newName: "IX_T_E_COMMANDE_COM_IdMarque");
        }
    }
}
