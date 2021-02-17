using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Data.Migrations
{
    public partial class imekartica1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Karta_KreditnaKartica_KKarticaID",
                table: "Karta");

            migrationBuilder.AlterColumn<int>(
                name: "KKarticaID",
                table: "Karta",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Karta_KreditnaKartica_KKarticaID",
                table: "Karta",
                column: "KKarticaID",
                principalTable: "KreditnaKartica",
                principalColumn: "KreditnaKarticaID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Karta_KreditnaKartica_KKarticaID",
                table: "Karta");

            migrationBuilder.AlterColumn<int>(
                name: "KKarticaID",
                table: "Karta",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Karta_KreditnaKartica_KKarticaID",
                table: "Karta",
                column: "KKarticaID",
                principalTable: "KreditnaKartica",
                principalColumn: "KreditnaKarticaID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
