using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TdBlanc.Migrations
{
    /// <inheritdoc />
    public partial class idutilisateur : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UTI_IDUTILISATEUR",
                schema: "public",
                table: "T_E_UTILISATEUR_UTI",
                newName: "UTI_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UTI_ID",
                schema: "public",
                table: "T_E_UTILISATEUR_UTI",
                newName: "UTI_IDUTILISATEUR");
        }
    }
}
