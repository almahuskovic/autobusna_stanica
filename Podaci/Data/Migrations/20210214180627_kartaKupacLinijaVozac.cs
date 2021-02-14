using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Data.Migrations
{
    public partial class kartaKupacLinijaVozac : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KartaKupac",
                columns: table => new
                {
                    KartaID = table.Column<int>(nullable: false),
                    KupacID = table.Column<string>(nullable: false)
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

            migrationBuilder.CreateTable(
                name: "LinijaVozac",
                columns: table => new
                {
                    LinijaID = table.Column<int>(nullable: false),
                    VozacID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinijaVozac", x => new { x.LinijaID, x.VozacID });
                    table.ForeignKey(
                        name: "FK_LinijaVozac_Linija_LinijaID",
                        column: x => x.LinijaID,
                        principalTable: "Linija",
                        principalColumn: "LinijaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LinijaVozac_Vozac_VozacID",
                        column: x => x.VozacID,
                        principalTable: "Vozac",
                        principalColumn: "VozacID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KartaKupac_KupacID",
                table: "KartaKupac",
                column: "KupacID");

            migrationBuilder.CreateIndex(
                name: "IX_LinijaVozac_VozacID",
                table: "LinijaVozac",
                column: "VozacID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KartaKupac");

            migrationBuilder.DropTable(
                name: "LinijaVozac");
        }
    }
}
