using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Podaci.Migrations
{
    public partial class obavijest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ObavijestKategorija",
                table: "ObavijestKategorija");

            migrationBuilder.DropColumn(
                name: "ObavijestID",
                table: "ObavijestKategorija");

            migrationBuilder.AddColumn<int>(
                name: "ObavijestKategorijaID",
                table: "ObavijestKategorija",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ObavijestKategorija",
                table: "ObavijestKategorija",
                column: "ObavijestKategorijaID");

            migrationBuilder.CreateTable(
                name: "Obavijest",
                columns: table => new
                {
                    ObavijestID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naslov = table.Column<string>(nullable: true),
                    Podnaslov = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true),
                    Slika = table.Column<string>(nullable: true),
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

            migrationBuilder.AddForeignKey(
                name: "FK_Grad_Drzava_DrzavaID",
                table: "Grad",
                column: "DrzavaID",
                principalTable: "Drzava",
                principalColumn: "DrzavaID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grad_Drzava_DrzavaID",
                table: "Grad");

            migrationBuilder.DropTable(
                name: "Obavijest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ObavijestKategorija",
                table: "ObavijestKategorija");

            migrationBuilder.DropIndex(
                name: "IX_Grad_DrzavaID",
                table: "Grad");

            migrationBuilder.DropColumn(
                name: "ObavijestKategorijaID",
                table: "ObavijestKategorija");

            migrationBuilder.AddColumn<int>(
                name: "ObavijestID",
                table: "ObavijestKategorija",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ObavijestKategorija",
                table: "ObavijestKategorija",
                column: "ObavijestID");
        }
    }
}
