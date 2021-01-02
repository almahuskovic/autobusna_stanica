using Microsoft.EntityFrameworkCore.Migrations;

namespace Podaci.Migrations
{
    public partial class linija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Linija",
                columns: table => new
                {
                    LinijaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OznakaLinije = table.Column<string>(nullable: true),
                    GPolaskaID = table.Column<int>(nullable: false),
                    GradPolaskaGradID = table.Column<int>(nullable: true),
                    GDolaskaID = table.Column<int>(nullable: false),
                    GradDolaskaGradID = table.Column<int>(nullable: true),
                    CijenaPovratna = table.Column<float>(nullable: false),
                    CijenaJednosmijerna = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Linija", x => x.LinijaID);
                    table.ForeignKey(
                        name: "FK_Linija_Grad_GradDolaskaGradID",
                        column: x => x.GradDolaskaGradID,
                        principalTable: "Grad",
                        principalColumn: "GradID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Linija_Grad_GradPolaskaGradID",
                        column: x => x.GradPolaskaGradID,
                        principalTable: "Grad",
                        principalColumn: "GradID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Linija_GradDolaskaGradID",
                table: "Linija",
                column: "GradDolaskaGradID");

            migrationBuilder.CreateIndex(
                name: "IX_Linija_GradPolaskaGradID",
                table: "Linija",
                column: "GradPolaskaGradID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Linija");
        }
    }
}
