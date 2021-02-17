using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Data.Migrations
{
    public partial class ppp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Karta_Stajalista_DolazisteID",
                table: "Karta");

            migrationBuilder.DropForeignKey(
                name: "FK_Karta_Stajalista_PolazisteID",
                table: "Karta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stajalista",
                table: "Stajalista");

            migrationBuilder.DropColumn(
                name: "StajaistaID",
                table: "Stajalista");

            migrationBuilder.AddColumn<int>(
                name: "StajalistaID",
                table: "Stajalista",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stajalista",
                table: "Stajalista",
                column: "StajalistaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Karta_Stajalista_DolazisteID",
                table: "Karta",
                column: "DolazisteID",
                principalTable: "Stajalista",
                principalColumn: "StajalistaID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Karta_Stajalista_PolazisteID",
                table: "Karta",
                column: "PolazisteID",
                principalTable: "Stajalista",
                principalColumn: "StajalistaID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Karta_Stajalista_DolazisteID",
                table: "Karta");

            migrationBuilder.DropForeignKey(
                name: "FK_Karta_Stajalista_PolazisteID",
                table: "Karta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stajalista",
                table: "Stajalista");

            migrationBuilder.DropColumn(
                name: "StajalistaID",
                table: "Stajalista");

            migrationBuilder.AddColumn<int>(
                name: "StajaistaID",
                table: "Stajalista",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stajalista",
                table: "Stajalista",
                column: "StajaistaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Karta_Stajalista_DolazisteID",
                table: "Karta",
                column: "DolazisteID",
                principalTable: "Stajalista",
                principalColumn: "StajaistaID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Karta_Stajalista_PolazisteID",
                table: "Karta",
                column: "PolazisteID",
                principalTable: "Stajalista",
                principalColumn: "StajaistaID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
