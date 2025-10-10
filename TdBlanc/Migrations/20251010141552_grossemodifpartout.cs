using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TdBlanc.Migrations
{
    /// <inheritdoc />
    public partial class grossemodifpartout : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_E_COMMANDE_COM_T_E_UTILISATEUR_UTI",
                schema: "public",
                table: "T_E_COMMANDE_COM");

            migrationBuilder.AddForeignKey(
                name: "FK_T_E_COMMANDE_COM_T_E_UTILISATEUR_UTI",
                schema: "public",
                table: "T_E_COMMANDE_COM",
                column: "UTI_ID",
                principalSchema: "public",
                principalTable: "T_E_UTILISATEUR_UTI",
                principalColumn: "UTI_ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_E_COMMANDE_COM_T_E_UTILISATEUR_UTI",
                schema: "public",
                table: "T_E_COMMANDE_COM");

            migrationBuilder.AddForeignKey(
                name: "FK_T_E_COMMANDE_COM_T_E_UTILISATEUR_UTI",
                schema: "public",
                table: "T_E_COMMANDE_COM",
                column: "UTI_ID",
                principalSchema: "public",
                principalTable: "T_E_UTILISATEUR_UTI",
                principalColumn: "UTI_ID");
        }
    }
}
