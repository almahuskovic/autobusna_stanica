using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Podaci.Migrations
{
    public partial class p : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drzava",
                columns: table => new
                {
                    DrzavaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drzava", x => x.DrzavaID);
                });

            migrationBuilder.CreateTable(
                name: "ObavijestKategorija",
                columns: table => new
                {
                    ObavijestKategorijaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObavijestKategorija", x => x.ObavijestKategorijaID);
                });

            migrationBuilder.CreateTable(
                name: "Grad",
                columns: table => new
                {
                    GradID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    DrzavaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grad", x => x.GradID);
                    table.ForeignKey(
                        name: "FK_Grad_Drzava_DrzavaID",
                        column: x => x.DrzavaID,
                        principalTable: "Drzava",
                        principalColumn: "DrzavaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Obavijest",
                columns: table => new
                {
                    ObavijestID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naslov = table.Column<string>(nullable: true),
                    Podnaslov = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true),
                    Slika = table.Column<byte[]>(nullable: true),
                    DatumObjave = table.Column<DateTime>(nullable: false),
                    ObavijestKategorijaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obavijest", x => x.ObavijestID);
                    table.ForeignKey(
                        name: "FK_Obavijest_ObavijestKategorija_ObavijestKategorijaID",
                        column: x => x.ObavijestKategorijaID,
                        principalTable: "ObavijestKategorija",
                        principalColumn: "ObavijestKategorijaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Grad_DrzavaID",
                table: "Grad",
                column: "DrzavaID");

            migrationBuilder.CreateIndex(
                name: "IX_Obavijest_ObavijestKategorijaID",
                table: "Obavijest",
                column: "ObavijestKategorijaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grad");

            migrationBuilder.DropTable(
                name: "Obavijest");

            migrationBuilder.DropTable(
                name: "Drzava");

            migrationBuilder.DropTable(
                name: "ObavijestKategorija");
        }
    }
}
