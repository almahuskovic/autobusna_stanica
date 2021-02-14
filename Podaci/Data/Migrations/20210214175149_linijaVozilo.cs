using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Data.Migrations
{
    public partial class linijaVozilo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "KupacID",
            //    table: "KreditnaKartica");

            migrationBuilder.AlterColumn<string>(
                name: "BrojKartice",
                table: "KreditnaKartica",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "LinijaVozilo",
                columns: table => new
                {
                    LinijaID = table.Column<int>(nullable: false),
                    VoziloID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinijaVozilo", x => new { x.LinijaID, x.VoziloID });
                    table.ForeignKey(
                        name: "FK_LinijaVozilo_Linija_LinijaID",
                        column: x => x.LinijaID,
                        principalTable: "Linija",
                        principalColumn: "LinijaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LinijaVozilo_Vozilo_VoziloID",
                        column: x => x.VoziloID,
                        principalTable: "Vozilo",
                        principalColumn: "VoziloID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LinijaVozilo_VoziloID",
                table: "LinijaVozilo",
                column: "VoziloID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LinijaVozilo");

            migrationBuilder.AlterColumn<int>(
                name: "BrojKartice",
                table: "KreditnaKartica",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "KupacID",
            //    table: "KreditnaKartica",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);
        }
    }
}
