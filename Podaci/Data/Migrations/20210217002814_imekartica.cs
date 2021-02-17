using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Data.Migrations
{
    public partial class imekartica : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Karta_KreditnaKartica_KreditnaKarticaID",
                table: "Karta");

            migrationBuilder.DropIndex(
                name: "IX_Karta_KreditnaKarticaID",
                table: "Karta");

            migrationBuilder.DropColumn(
                name: "KreditnaKarticaID",
                table: "Karta");

            migrationBuilder.AddColumn<int>(
                name: "KKarticaID",
                table: "Karta",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Karta_KKarticaID",
                table: "Karta",
                column: "KKarticaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Karta_KreditnaKartica_KKarticaID",
                table: "Karta",
                column: "KKarticaID",
                principalTable: "KreditnaKartica",
                principalColumn: "KreditnaKarticaID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Karta_KreditnaKartica_KKarticaID",
                table: "Karta");

            migrationBuilder.DropIndex(
                name: "IX_Karta_KKarticaID",
                table: "Karta");

            migrationBuilder.DropColumn(
                name: "KKarticaID",
                table: "Karta");

            migrationBuilder.AddColumn<int>(
                name: "KreditnaKarticaID",
                table: "Karta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Karta_KreditnaKarticaID",
                table: "Karta",
                column: "KreditnaKarticaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Karta_KreditnaKartica_KreditnaKarticaID",
                table: "Karta",
                column: "KreditnaKarticaID",
                principalTable: "KreditnaKartica",
                principalColumn: "KreditnaKarticaID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
