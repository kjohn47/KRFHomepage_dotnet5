using Microsoft.EntityFrameworkCore.Migrations;

namespace KRFHomepage.Infrastructure.Database.Migrations
{
    public partial class InitialTranslations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Value = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Value);
                });

            migrationBuilder.CreateTable(
                name: "languages",
                columns: table => new
                {
                    Code = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_languages", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "tokens",
                columns: table => new
                {
                    Value = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tokens", x => x.Value);
                });

            migrationBuilder.CreateTable(
                name: "translations",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TokenValue = table.Column<string>(nullable: false),
                    LanguageCode = table.Column<string>(nullable: false),
                    TranslationCategoryValue = table.Column<string>(nullable: false),
                    Text = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_translations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_translations_languages_LanguageCode",
                        column: x => x.LanguageCode,
                        principalTable: "languages",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_translations_tokens_TokenValue",
                        column: x => x.TokenValue,
                        principalTable: "tokens",
                        principalColumn: "Value",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_translations_categories_TranslationCategoryValue",
                        column: x => x.TranslationCategoryValue,
                        principalTable: "categories",
                        principalColumn: "Value",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "categories",
                column: "Value",
                values: new object[]
                {
                    "_datePicker",
                    "_tableText",
                    "_generic",
                    "_TestPage"
                });

            migrationBuilder.InsertData(
                table: "languages",
                columns: new[] { "Code", "Name" },
                values: new object[,]
                {
                    { "PT", "Portuguese" },
                    { "EN", "English" }
                });

            migrationBuilder.InsertData(
                table: "tokens",
                column: "Value",
                values: new object[]
                {
                    "#(cardDetails)",
                    "#(loadingText)",
                    "#(Sun)",
                    "#(Sat)",
                    "#(Fri)",
                    "#(Thu)",
                    "#(Wed)",
                    "#(Tue)",
                    "#(Mon)",
                    "#(December)",
                    "#(November)",
                    "#(goBackToHomeToolTip)",
                    "#(October)",
                    "#(August)",
                    "#(goBackToHome)",
                    "#(June)",
                    "#(May)",
                    "#(April)",
                    "#(March)",
                    "#(February)",
                    "#(January)",
                    "#(TestPage Title)",
                    "#(remove)",
                    "#(edit)",
                    "#(September)",
                    "#(July)"
                });

            migrationBuilder.InsertData(
                table: "translations",
                columns: new[] { "ID", "LanguageCode", "Text", "TokenValue", "TranslationCategoryValue" },
                values: new object[,]
                {
                    { 1, "PT", "A Carregar!", "#(loadingText)", "_generic" },
                    { 22, "PT", "Qua", "#(Wed)", "_datePicker" },
                    { 23, "PT", "Qui", "#(Thu)", "_datePicker" },
                    { 24, "PT", "Sex", "#(Fri)", "_datePicker" },
                    { 25, "PT", "Sab", "#(Sat)", "_datePicker" },
                    { 26, "PT", "Dom", "#(Sun)", "_datePicker" },
                    { 34, "EN", "January", "#(January)", "_datePicker" },
                    { 35, "EN", "February", "#(February)", "_datePicker" },
                    { 36, "EN", "March", "#(March)", "_datePicker" },
                    { 37, "EN", "April", "#(April)", "_datePicker" },
                    { 38, "EN", "May", "#(May)", "_datePicker" },
                    { 21, "PT", "Ter", "#(Tue)", "_datePicker" },
                    { 39, "EN", "June", "#(June)", "_datePicker" },
                    { 41, "EN", "August", "#(August)", "_datePicker" },
                    { 42, "EN", "September", "#(September)", "_datePicker" },
                    { 43, "EN", "October", "#(October)", "_datePicker" },
                    { 44, "EN", "November", "#(November)", "_datePicker" },
                    { 45, "EN", "December", "#(December)", "_datePicker" },
                    { 46, "EN", "Mon", "#(Mon)", "_datePicker" },
                    { 47, "EN", "Tue", "#(Tue)", "_datePicker" },
                    { 48, "EN", "Wed", "#(Wed)", "_datePicker" },
                    { 49, "EN", "Thu", "#(Thu)", "_datePicker" },
                    { 50, "EN", "Fri", "#(Fri)", "_datePicker" },
                    { 40, "EN", "July", "#(July)", "_datePicker" },
                    { 20, "PT", "Seg", "#(Mon)", "_datePicker" },
                    { 19, "PT", "Dezembro", "#(December)", "_datePicker" },
                    { 18, "PT", "Novembro", "#(November)", "_datePicker" },
                    { 2, "PT", "Voltar para Homepage", "#(goBackToHome)", "_generic" },
                    { 3, "PT", "Carregue no botão para retomar para a homepage.", "#(goBackToHomeToolTip)", "_generic" },
                    { 4, "PT", "Ver detalhes", "#(cardDetails)", "_generic" },
                    { 27, "EN", "Loading!", "#(loadingText)", "_generic" },
                    { 28, "EN", "Go back to Homepage", "#(goBackToHome)", "_generic" },
                    { 29, "EN", "Click at the button to return to homepage.", "#(goBackToHomeToolTip)", "_generic" },
                    { 30, "EN", "View details", "#(cardDetails)", "_generic" },
                    { 5, "PT", "Editar", "#(edit)", "_tableText" },
                    { 6, "PT", "Remover", "#(remove)", "_tableText" },
                    { 31, "EN", "Edit", "#(edit)", "_tableText" },
                    { 32, "EN", "Remove", "#(remove)", "_tableText" },
                    { 7, "PT", "Página de Teste de Componentes", "#(TestPage Title)", "_TestPage" },
                    { 33, "EN", "Component Test Page", "#(TestPage Title)", "_TestPage" },
                    { 8, "PT", "Janeiro", "#(January)", "_datePicker" },
                    { 9, "PT", "Fevereiro", "#(February)", "_datePicker" },
                    { 10, "PT", "Março", "#(March)", "_datePicker" },
                    { 11, "PT", "Abril", "#(April)", "_datePicker" },
                    { 12, "PT", "Maio", "#(May)", "_datePicker" },
                    { 13, "PT", "Junho", "#(June)", "_datePicker" },
                    { 14, "PT", "Julho", "#(July)", "_datePicker" },
                    { 15, "PT", "Agosto", "#(August)", "_datePicker" },
                    { 16, "PT", "Setembro", "#(September)", "_datePicker" },
                    { 17, "PT", "Outubro", "#(October)", "_datePicker" },
                    { 51, "EN", "Sat", "#(Sat)", "_datePicker" },
                    { 52, "EN", "Sun", "#(Sun)", "_datePicker" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_translations_LanguageCode",
                table: "translations",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_translations_TokenValue",
                table: "translations",
                column: "TokenValue");

            migrationBuilder.CreateIndex(
                name: "IX_translations_TranslationCategoryValue",
                table: "translations",
                column: "TranslationCategoryValue");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "translations");

            migrationBuilder.DropTable(
                name: "languages");

            migrationBuilder.DropTable(
                name: "tokens");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
