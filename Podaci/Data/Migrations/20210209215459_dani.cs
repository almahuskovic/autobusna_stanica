using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Data.Migrations
{
    public partial class dani : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "Sjediste",
            //    table: "Karta");

            migrationBuilder.AlterColumn<string>(
                name: "DatumZadnjegServisa",
                table: "Vozilo",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "DatumObjave",
                table: "Obavijest",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "DaniUSedmici",
                table: "Linija",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "VaziOd",
                table: "Karta",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "VaziDo",
                table: "Karta",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Datum",
                table: "Karta",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            //migrationBuilder.AddColumn<int>(
            //    name: "DolazisteID",
            //    table: "Karta",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.AddColumn<int>(
            //    name: "PolazisteID",
            //    table: "Karta",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.AddColumn<string>(
            //    name: "Discriminator",
            //    table: "AspNetUsers",
            //    nullable: false,
            //    defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Adresa",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DatumZaposlenja",
                table: "AspNetUsers",
                nullable: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Karta_DolazisteID",
            //    table: "Karta",
            //    column: "DolazisteID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Karta_PolazisteID",
            //    table: "Karta",
            //    column: "PolazisteID");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Karta_Stajalista_DolazisteID",
            //    table: "Karta",
            //    column: "DolazisteID",
            //    principalTable: "Stajalista",
            //    principalColumn: "StajaistaID",
            //    onDelete: ReferentialAction.NoAction);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Karta_Stajalista_PolazisteID",
            //    table: "Karta",
            //    column: "PolazisteID",
            //    principalTable: "Stajalista",
            //    principalColumn: "StajaistaID",
            //    onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Karta_Stajalista_DolazisteID",
                table: "Karta");

            migrationBuilder.DropForeignKey(
                name: "FK_Karta_Stajalista_PolazisteID",
                table: "Karta");

            migrationBuilder.DropIndex(
                name: "IX_Karta_DolazisteID",
                table: "Karta");

            migrationBuilder.DropIndex(
                name: "IX_Karta_PolazisteID",
                table: "Karta");

            migrationBuilder.DropColumn(
                name: "DaniUSedmici",
                table: "Linija");

            //migrationBuilder.DropColumn(
            //    name: "DolazisteID",
            //    table: "Karta");

            //migrationBuilder.DropColumn(
            //    name: "PolazisteID",
            //    table: "Karta");

            //migrationBuilder.DropColumn(
            //    name: "Discriminator",
            //    table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Adresa",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DatumZaposlenja",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DatumZadnjegServisa",
                table: "Vozilo",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DatumObjave",
                table: "Obavijest",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "VaziOd",
                table: "Karta",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "VaziDo",
                table: "Karta",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Datum",
                table: "Karta",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "Sjediste",
            //    table: "Karta",
            //    type: "nvarchar(max)",
            //    nullable: true);
        }
    }
}
