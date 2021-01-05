using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Data.Migrations
{
    public partial class TipKarte : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BrojKreditneKartice",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KupacID",
                table: "AspNetUsers",
                nullable: true);

            //migrationBuilder.CreateTable(
            //    name: "Feedback",
            //    columns: table => new
            //    {
            //        FeedbackID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Opis = table.Column<string>(nullable: true),
            //        Ocjena = table.Column<string>(nullable: true),
            //        KupacId = table.Column<string>(nullable: true),
            //        KupacID = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Feedback", x => x.FeedbackID);
            //        table.ForeignKey(
            //            name: "FK_Feedback_AspNetUsers_KupacId",
            //            column: x => x.KupacId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            migrationBuilder.CreateTable(
                name: "TipKarte",
                columns: table => new
                {
                    TipKarteID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipKarte", x => x.TipKarteID);
                });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Feedback_KupacId",
            //    table: "Feedback",
            //    column: "KupacId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "Feedback");

            migrationBuilder.DropTable(
                name: "TipKarte");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BrojKreditneKartice",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "KupacID",
                table: "AspNetUsers");
        }
    }
}
