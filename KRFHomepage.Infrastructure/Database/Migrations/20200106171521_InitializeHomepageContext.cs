using Microsoft.EntityFrameworkCore.Migrations;

namespace KRFHomepage.Infrastructure.Database.Migrations
{
    public partial class InitializeHomepageContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "homepages",
                columns: table => new
                {
                    LanguageCode = table.Column<string>(nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    SubTitle = table.Column<string>(maxLength: 200, nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_homepages", x => x.LanguageCode);
                    table.ForeignKey(
                        name: "FK_homepages_languages_LanguageCode",
                        column: x => x.LanguageCode,
                        principalTable: "languages",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "homepages",
                columns: new[] { "LanguageCode", "Description", "SubTitle", "Title" },
                values: new object[] { "PT", "Bem Vindo ao KRF, isto é uma framework react para fazer desenvolvimento divertido :)", "A página principal do KRF com microserviços", "KJohn React Framework" });

            migrationBuilder.InsertData(
                table: "homepages",
                columns: new[] { "LanguageCode", "Description", "SubTitle", "Title" },
                values: new object[] { "EN", "Welcome to KRF, this is a react framework to make some fun dev :)", "The KRF homepage with microservices", "KJohn React Framework" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "homepages");
        }
    }
}
