using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Podaci.Migrations
{
    public partial class obavijesti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
               name: "IX_Obavijest_ObavijestKategorijaID",
               table: "Obavijest",
               column: "ObavijestKategorijaID");

            //migrationBuilder.AlterColumn<int>(
            //    name: "ObavijestKategorijaID",
            //    table: "Obavijest",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldNullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "ObavijestID",
            //    table: "Obavijest",
            //    nullable: false,
            //    defaultValue: 0)
            //    .Annotation("SqlServer:Identity", "1, 1");

            //migrationBuilder.AddColumn<DateTime>(
            //    name: "DatumObjave",
            //    table: "Obavijest",
            //    nullable: false,
            //    defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            //migrationBuilder.AddColumn<string>(
            //    name: "Naslov",
            //    table: "Obavijest",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "Opis",
            //    table: "Obavijest",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "Podnaslov",
            //    table: "Obavijest",
            //    nullable: true);

            //migrationBuilder.AddColumn<byte[]>(
            //    name: "Slika",
            //    table: "Obavijest",
            //    nullable: true);

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_Obavijest",
            //    table: "Obavijest",
            //    column: "ObavijestID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Obavijest_ObavijestKategorijaID",
            //    table: "Obavijest",
            //    column: "ObavijestKategorijaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
              name: "Obavijest");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_Obavijest",
            //    table: "Obavijest");

            //migrationBuilder.DropIndex(
            //    name: "IX_Obavijest_ObavijestKategorijaID",
            //    table: "Obavijest");

            //migrationBuilder.DropColumn(
            //    name: "ObavijestID",
            //    table: "Obavijest");

            //migrationBuilder.DropColumn(
            //    name: "DatumObjave",
            //    table: "Obavijest");

            //migrationBuilder.DropColumn(
            //    name: "Naslov",
            //    table: "Obavijest");

            //migrationBuilder.DropColumn(
            //    name: "Opis",
            //    table: "Obavijest");

            //migrationBuilder.DropColumn(
            //    name: "Podnaslov",
            //    table: "Obavijest");

            //migrationBuilder.DropColumn(
            //    name: "Slika",
            //    table: "Obavijest");

            //migrationBuilder.AlterColumn<int>(
            //    name: "ObavijestKategorijaID",
            //    table: "Obavijest",
            //    nullable: true,
            //    oldClrType: typeof(int));
        }
    }
}
