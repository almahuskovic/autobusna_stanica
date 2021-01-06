using Microsoft.EntityFrameworkCore.Migrations;

namespace Podaci.Migrations
{
    public partial class stajalista : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stajalista",
                columns: table => new
                {
                    StajaistaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinijaID = table.Column<int>(nullable: false),
                    GradID = table.Column<int>(nullable: false),
                    SatnicaStizanja = table.Column<string>(nullable: true),
                    RedniBrojStajalista = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stajalista", x => x.StajaistaID);
                    table.ForeignKey(
                        name: "FK_Stajalista_Grad_GradID",
                        column: x => x.GradID,
                        principalTable: "Grad",
                        principalColumn: "GradID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stajalista_Linija_LinijaID",
                        column: x => x.LinijaID,
                        principalTable: "Linija",
                        principalColumn: "LinijaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stajalista_GradID",
                table: "Stajalista",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "IX_Stajalista_LinijaID",
                table: "Stajalista",
                column: "LinijaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stajalista");
        }
    }
}
