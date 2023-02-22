using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API_Movie.Migrations
{
    public partial class APIFilms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_E_FILM_FLM",
                columns: table => new
                {
                    flm_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    flm_titre = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    flm_resume = table.Column<string>(type: "text", nullable: false),
                    flm_datesortie = table.Column<DateTime>(type: "date", nullable: false),
                    flm_duree = table.Column<decimal>(type: "numeric(3,0)", nullable: false),
                    flm_genre = table.Column<string>(type: "varchar", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_E_FILM_FLM", x => x.flm_id);
                });

            migrationBuilder.CreateTable(
                name: "T_E_UTILISATEUR_UTL",
                columns: table => new
                {
                    utl_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    utl_nom = table.Column<string>(type: "varchar", maxLength: 50, nullable: true),
                    utl_prenom = table.Column<string>(type: "varchar", maxLength: 50, nullable: true),
                    utl_mobile = table.Column<string>(type: "char(10)", nullable: true),
                    utl_mail = table.Column<string>(type: "varchar", maxLength: 100, nullable: true),
                    utl_pwd = table.Column<string>(type: "varchar", maxLength: 64, nullable: true),
                    utl_rue = table.Column<string>(type: "varchar", maxLength: 200, nullable: true),
                    utl_cp = table.Column<string>(type: "char(5)", nullable: true),
                    utl_ville = table.Column<string>(type: "varchar", maxLength: 50, nullable: true),
                    utl_pays = table.Column<string>(type: "varchar", maxLength: 50, nullable: true),
                    utl_latitude = table.Column<float>(type: "real", nullable: true),
                    utl_longitude = table.Column<float>(type: "real", nullable: true),
                    utl_datecreation = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_E_UTILISATEUR_UTL", x => x.utl_id);
                });

            migrationBuilder.CreateTable(
                name: "T_J_NOTATION_NOT",
                columns: table => new
                {
                    UtilisateurId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FilmId = table.Column<int>(type: "integer", nullable: false),
                    not_note = table.Column<int>(type: "int", nullable: false),
                    T_E_UTILISATEUR_UTL = table.Column<int>(type: "int", nullable: false),
                    T_E_FILM_FLM = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_J_NOTATION_NOT", x => x.UtilisateurId);
                    table.ForeignKey(
                        name: "FK_T_J_NOTATION_NOT_T_E_FILM_FLM_T_E_FILM_FLM",
                        column: x => x.T_E_FILM_FLM,
                        principalTable: "T_E_FILM_FLM",
                        principalColumn: "flm_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_J_NOTATION_NOT_T_E_UTILISATEUR_UTL_T_E_UTILISATEUR_UTL",
                        column: x => x.T_E_UTILISATEUR_UTL,
                        principalTable: "T_E_UTILISATEUR_UTL",
                        principalColumn: "utl_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_J_NOTATION_NOT_T_E_FILM_FLM",
                table: "T_J_NOTATION_NOT",
                column: "T_E_FILM_FLM");

            migrationBuilder.CreateIndex(
                name: "IX_T_J_NOTATION_NOT_T_E_UTILISATEUR_UTL",
                table: "T_J_NOTATION_NOT",
                column: "T_E_UTILISATEUR_UTL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_J_NOTATION_NOT");

            migrationBuilder.DropTable(
                name: "T_E_FILM_FLM");

            migrationBuilder.DropTable(
                name: "T_E_UTILISATEUR_UTL");
        }
    }
}
