using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Data.Migrations
{
    public partial class naglePromjene : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KartaKupac");

            migrationBuilder.AddColumn<bool>(
                name: "IsAktivna",
                table: "Karta",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "KupacId",
                table: "Karta",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NazivLinije",
                table: "Karta",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Karta_KupacId",
                table: "Karta",
                column: "KupacId");

            migrationBuilder.AddForeignKey(
                name: "FK_Karta_AspNetUsers_KupacId",
                table: "Karta",
                column: "KupacId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Karta_AspNetUsers_KupacId",
                table: "Karta");

            migrationBuilder.DropIndex(
                name: "IX_Karta_KupacId",
                table: "Karta");

            migrationBuilder.DropColumn(
                name: "IsAktivna",
                table: "Karta");

            migrationBuilder.DropColumn(
                name: "KupacId",
                table: "Karta");

            migrationBuilder.DropColumn(
                name: "NazivLinije",
                table: "Karta");

            migrationBuilder.CreateTable(
                name: "KartaKupac",
                columns: table => new
                {
                    KartaID = table.Column<int>(type: "int", nullable: false),
                    KupacID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KartaKupac", x => new { x.KartaID, x.KupacID });
                    table.ForeignKey(
                        name: "FK_KartaKupac_Karta_KartaID",
                        column: x => x.KartaID,
                        principalTable: "Karta",
                        principalColumn: "KartaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KartaKupac_AspNetUsers_KupacID",
                        column: x => x.KupacID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KartaKupac_KupacID",
                table: "KartaKupac",
                column: "KupacID");
        }
    }
}
