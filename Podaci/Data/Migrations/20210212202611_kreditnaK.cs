using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Data.Migrations
{
    public partial class kreditnaK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KreditnaKarticaID",
                table: "Karta",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "KreditnaKartica",
                columns: table => new
                {
                    KreditnaKarticaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojKartice = table.Column<int>(nullable: false),
                    DatumIsteka = table.Column<string>(nullable: true),
                    ImeVlasnikaKartice = table.Column<string>(nullable: true),
                    VerifikacijskiKod = table.Column<int>(nullable: false),
                    //KupacID = table.Column<int>(nullable: false),
                    KupacId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KreditnaKartica", x => x.KreditnaKarticaID);
                    table.ForeignKey(
                        name: "FK_KreditnaKartica_AspNetUsers_KupacId",
                        column: x => x.KupacId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Karta_KreditnaKarticaID",
                table: "Karta",
                column: "KreditnaKarticaID");

            migrationBuilder.CreateIndex(
                name: "IX_KreditnaKartica_KupacId",
                table: "KreditnaKartica",
                column: "KupacId");

            migrationBuilder.AddForeignKey(
                name: "FK_Karta_KreditnaKartica_KreditnaKarticaID",
                table: "Karta",
                column: "KreditnaKarticaID",
                principalTable: "KreditnaKartica",
                principalColumn: "KreditnaKarticaID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Karta_KreditnaKartica_KreditnaKarticaID",
                table: "Karta");

            migrationBuilder.DropTable(
                name: "KreditnaKartica");

            migrationBuilder.DropIndex(
                name: "IX_Karta_KreditnaKarticaID",
                table: "Karta");

            migrationBuilder.DropColumn(
                name: "KreditnaKarticaID",
                table: "Karta");
        }
    }
}
