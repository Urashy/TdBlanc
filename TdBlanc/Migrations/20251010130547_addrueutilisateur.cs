using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TdBlanc.Migrations
{
    /// <inheritdoc />
    public partial class addrueutilisateur : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UTI_RUE",
                schema: "public",
                table: "T_E_UTILISATEUR_UTI",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UTI_RUE",
                schema: "public",
                table: "T_E_UTILISATEUR_UTI");
        }
    }
}
