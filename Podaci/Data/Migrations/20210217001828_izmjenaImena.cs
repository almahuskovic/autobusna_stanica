using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Data.Migrations
{
    public partial class izmjenaImena : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrojPutnika",
                table: "Karta");

            migrationBuilder.DropColumn(
                name: "Datum",
                table: "Karta");

            migrationBuilder.DropColumn(
                name: "IsRezervisana",
                table: "Karta");

            migrationBuilder.DropColumn(
                name: "VaziDo",
                table: "Karta");

            migrationBuilder.DropColumn(
                name: "VaziOd",
                table: "Karta");

            migrationBuilder.AddColumn<float>(
                name: "Cijena",
                table: "Karta",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "DatumDolaska",
                table: "Karta",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DatumKupovine",
                table: "Karta",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DatumPolaska",
                table: "Karta",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cijena",
                table: "Karta");

            migrationBuilder.DropColumn(
                name: "DatumDolaska",
                table: "Karta");

            migrationBuilder.DropColumn(
                name: "DatumKupovine",
                table: "Karta");

            migrationBuilder.DropColumn(
                name: "DatumPolaska",
                table: "Karta");

            migrationBuilder.AddColumn<int>(
                name: "BrojPutnika",
                table: "Karta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Datum",
                table: "Karta",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRezervisana",
                table: "Karta",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "VaziDo",
                table: "Karta",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VaziOd",
                table: "Karta",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
