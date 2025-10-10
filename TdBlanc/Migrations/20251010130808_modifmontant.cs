using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TdBlanc.Migrations
{
    /// <inheritdoc />
    public partial class modifmontant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UTI_Montant",
                schema: "public",
                table: "T_E_COMMANDE_COM",
                newName: "COM_Montant");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "COM_Montant",
                schema: "public",
                table: "T_E_COMMANDE_COM",
                newName: "UTI_Montant");
        }
    }
}
