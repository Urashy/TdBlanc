using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TdBlanc.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_E_UTILISATEUR_UTI",
                columns: table => new
                {
                    UTI_IDUTILISATEUR = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UTI_NOM = table.Column<string>(type: "text", nullable: true),
                    UTI_PRENOM = table.Column<string>(type: "text", nullable: true),
                    UTI_NUMERORUE = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    UTI_CODEPOSTAL = table.Column<int>(type: "integer", maxLength: 5, nullable: false),
                    UTI_VILLE = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_E_UTILISATEUR_UTI", x => x.UTI_IDUTILISATEUR);
                });

            migrationBuilder.CreateTable(
                name: "T_E_COMMANDE_COM",
                columns: table => new
                {
                    COM_IDCOMMANDE = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    COM_NOMARTICLE = table.Column<string>(type: "text", nullable: true),
                    UTI_Montant = table.Column<double>(type: "double precision", nullable: false),
                    IdMarque = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_E_COMMANDE_COM", x => x.COM_IDCOMMANDE);
                    table.ForeignKey(
                        name: "FK_T_E_COMMANDE_COM_T_E_UTILISATEUR_UTI",
                        column: x => x.IdMarque,
                        principalTable: "T_E_UTILISATEUR_UTI",
                        principalColumn: "UTI_IDUTILISATEUR");
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_E_COMMANDE_COM_IdMarque",
                table: "T_E_COMMANDE_COM",
                column: "IdMarque");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_E_COMMANDE_COM");

            migrationBuilder.DropTable(
                name: "T_E_UTILISATEUR_UTI");
        }
    }
}
