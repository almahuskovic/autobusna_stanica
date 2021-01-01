using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Podaci.Migrations
{
    public partial class brisanjeTipaUposlenika : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TipUposlenika");

        //    migrationBuilder.AlterColumn<int>(
        //        name: "ObavijestKategorijaID",
        //        table: "Obavijest",
        //        nullable: false,
        //        oldClrType: typeof(int),
        //        oldNullable: true);

        //    migrationBuilder.AddColumn<int>(
        //        name: "ObavijestID",
        //        table: "Obavijest",
        //        nullable: false,
        //        defaultValue: 0)
        //        .Annotation("SqlServer:Identity", "1, 1");

        //    migrationBuilder.AddColumn<DateTime>(
        //        name: "DatumObjave",
        //        table: "Obavijest",
        //        nullable: false,
        //        defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

        //    migrationBuilder.AddColumn<string>(
        //        name: "Naslov",
        //        table: "Obavijest",
        //        nullable: true);

        //    migrationBuilder.AddColumn<string>(
        //        name: "Opis",
        //        table: "Obavijest",
        //        nullable: true);

        //    migrationBuilder.AddColumn<string>(
        //        name: "Podnaslov",
        //        table: "Obavijest",
        //        nullable: true);

        //    migrationBuilder.AddColumn<byte[]>(
        //        name: "Slika",
        //        table: "Obavijest",
        //        nullable: true);

        //    migrationBuilder.AddPrimaryKey(
        //        name: "PK_Obavijest",
        //        table: "Obavijest",
        //        column: "ObavijestID");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Obavijest_ObavijestKategorijaID",
        //        table: "Obavijest",
        //        column: "ObavijestKategorijaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "TipUposlenika",
                columns: table => new
                {
                    TipUposlenikaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipUposlenika", x => x.TipUposlenikaID);
                });
        }
    }
}
