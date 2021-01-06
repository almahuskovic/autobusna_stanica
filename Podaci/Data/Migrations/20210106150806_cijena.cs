using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Data.Migrations
{
    public partial class cijena : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cijena",
                columns: table => new
                {
                    CijenaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GradPolaskaGradID = table.Column<int>(nullable: false),
                    GradDolaskaGradID = table.Column<int>(nullable: false),
                    JednosmijernaKartaCijena = table.Column<float>(nullable: false),
                    PovratnaKartaCijena = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cijena", x => x.CijenaID);
                    table.ForeignKey(
                        name: "FK_Cijena_Grad_GradDolaskaGradID",
                        column: x => x.GradDolaskaGradID,
                        principalTable: "Grad",
                        principalColumn: "GradID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Cijena_Grad_GradPolaskaGradID",
                        column: x => x.GradPolaskaGradID,
                        principalTable: "Grad",
                        principalColumn: "GradID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cijena_GradDolaskaGradID",
                table: "Cijena",
                column: "GradDolaskaGradID");

            migrationBuilder.CreateIndex(
                name: "IX_Cijena_GradPolaskaGradID",
                table: "Cijena",
                column: "GradPolaskaGradID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cijena");
        }
    }
}
