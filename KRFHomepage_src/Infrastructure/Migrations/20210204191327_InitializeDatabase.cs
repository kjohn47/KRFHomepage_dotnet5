using Microsoft.EntityFrameworkCore.Migrations;

namespace KRFHomepage.Infrastructure.Migrations
{
    public partial class InitializeDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Value = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORIES", x => x.Value);
                });

            migrationBuilder.CreateTable(
                name: "error_code",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorCode", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "languages",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LANGUAGE", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "tokens",
                columns: table => new
                {
                    Value = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TOKEN", x => x.Value);
                });

            migrationBuilder.CreateTable(
                name: "error_translations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(5)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorTranslations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ErrorTranslation_ErrorCode",
                        column: x => x.Code,
                        principalTable: "error_code",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ErrorTranslation_LanguageCode",
                        column: x => x.LanguageCode,
                        principalTable: "languages",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "homepages",
                columns: table => new
                {
                    LanguageCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SubTitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HOMEPAGE", x => x.LanguageCode);
                    table.ForeignKey(
                        name: "FK_HOMEPAGE_LANGUAGECODE",
                        column: x => x.LanguageCode,
                        principalTable: "languages",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "translations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TokenValue = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    TranslationCategoryValue = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Text = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRANSLATIONS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Translations_LanguageCode",
                        column: x => x.LanguageCode,
                        principalTable: "languages",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Translations_TokenValue",
                        column: x => x.TokenValue,
                        principalTable: "tokens",
                        principalColumn: "Value",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Translations_TranslationCategoryValue",
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
                    "_dropdown",
                    "_modal",
                    "_notificationMenu",
                    "_loginform",
                    "_menu",
                    "_brand",
                    "_datePicker",
                    "_TestPage",
                    "_tableText",
                    "_generic",
                    "_cookieModal"
                });

            migrationBuilder.InsertData(
                table: "error_code",
                column: "Code",
                values: new object[]
                {
                    "GenericError",
                    "PageNotFound",
                    "AdminOnlyError",
                    "AbortError"
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
                    "#(April)",
                    "#(NotificationHeader)",
                    "#(FromDateToDate)",
                    "#(OldUnreadedNotification)",
                    "#(ViewAll)",
                    "#(Yes)",
                    "#(No)",
                    "#(Ok)",
                    "#(ModalTest1)",
                    "#(ModalTest2)",
                    "#(CookiesModal)",
                    "#(CookiesModalDescription)",
                    "#(CookieAnalyticDescription)",
                    "#(CookieKey)",
                    "#(CookieDescription)",
                    "#(no_option)",
                    "#(opt_2)",
                    "#(January)",
                    "#(TestPage Title)",
                    "#(remove)",
                    "#(edit)",
                    "#(cardDetails)",
                    "#(goBackToHomeToolTip)",
                    "#(goBackToHome)",
                    "#(loadingText)"
                });

            migrationBuilder.InsertData(
                table: "tokens",
                column: "Value",
                values: new object[]
                {
                    "#(Tooltip)",
                    "#(NewLogin)",
                    "#(LoginDrop)",
                    "#(LoginButton)",
                    "#(May)",
                    "#(June)",
                    "#(July)",
                    "#(August)",
                    "#(September)",
                    "#(October)",
                    "#(November)",
                    "#(December)",
                    "#(Mon)",
                    "#(Tue)",
                    "#(Wed)",
                    "#(Thu)",
                    "#(March)",
                    "#(Fri)",
                    "#(Sun)",
                    "#(Cancel)",
                    "#(krf)",
                    "#(User)",
                    "#(Administration)",
                    "#(February)",
                    "#(Test1)",
                    "#(Test2)",
                    "#(SubTest1)",
                    "#(SubTest2)",
                    "#(Username)",
                    "#(Password)",
                    "#(Sat)",
                    "#(Logout)"
                });

            migrationBuilder.InsertData(
                table: "error_translations",
                columns: new[] { "ID", "Code", "LanguageCode", "Message", "Title" },
                values: new object[,]
                {
                    { 1, "GenericError", "PT", "Erro Genérico", "Erro Genérico" },
                    { 5, "GenericError", "EN", "Generic Error", "Generic Error" },
                    { 2, "PageNotFound", "PT", "Página não encontrada", "Página não encontrada" },
                    { 6, "PageNotFound", "EN", "Page not found", "Page not found" },
                    { 3, "AdminOnlyError", "PT", "Página só se encontrada disponível para administração!", "Apenas Administrador" },
                    { 7, "AdminOnlyError", "EN", "This page is only available for administration!", "Administrator Only" },
                    { 4, "AbortError", "PT", "A chamada ao serviço foi abortada ou terminou o tempo de espera", "Chamada a serviço abortada" },
                    { 8, "AbortError", "EN", "The call to service was aborted or service Timed Out", "Aborted service call" }
                });

            migrationBuilder.InsertData(
                table: "homepages",
                columns: new[] { "LanguageCode", "Description", "SubTitle", "Title" },
                values: new object[,]
                {
                    { "PT", "Bem Vindo ao KRF, isto é uma framework react para fazer desenvolvimento divertido :)", "A página principal do KRF com microserviços", "KJohn React Framework" },
                    { "EN", "Welcome to KRF, this is a react framework to make some fun dev :)", "The KRF homepage with microservices", "KJohn React Framework" }
                });

            migrationBuilder.InsertData(
                table: "translations",
                columns: new[] { "ID", "LanguageCode", "Text", "TokenValue", "TranslationCategoryValue" },
                values: new object[,]
                {
                    { 40, "PT", "Registar", "#(NewLogin)", "_loginform" },
                    { 94, "EN", "Username", "#(Username)", "_loginform" },
                    { 95, "EN", "Password", "#(Password)", "_loginform" },
                    { 96, "EN", "SignIn", "#(LoginButton)", "_loginform" },
                    { 97, "EN", "Login", "#(LoginDrop)", "_loginform" },
                    { 44, "PT", "Existem {0} notificações por ler de datas anteriores a {1}, clique aqui para vêr lista de não lidas", "#(OldUnreadedNotification)", "_notificationMenu" },
                    { 41, "PT", "Notificações", "#(Tooltip)", "_notificationMenu" },
                    { 42, "PT", "Lista de Notificações", "#(NotificationHeader)", "_notificationMenu" },
                    { 43, "PT", "De {0} até {1}", "#(FromDateToDate)", "_notificationMenu" },
                    { 39, "PT", "Entrar", "#(LoginDrop)", "_loginform" },
                    { 98, "EN", "SignUp", "#(NewLogin)", "_loginform" },
                    { 38, "PT", "Entrar", "#(LoginButton)", "_loginform" },
                    { 91, "EN", "Test 2", "#(Test2)", "_menu" },
                    { 36, "PT", "Utilizador", "#(Username)", "_loginform" },
                    { 93, "EN", "Submenu 2", "#(SubTest2)", "_menu" },
                    { 92, "EN", "Submenu 1", "#(SubTest1)", "_menu" },
                    { 45, "PT", "Ver Todas", "#(ViewAll)", "_notificationMenu" },
                    { 90, "EN", "Test 1", "#(Test1)", "_menu" },
                    { 89, "EN", "Logout", "#(Logout)", "_menu" },
                    { 88, "EN", "Administration", "#(Administration)", "_menu" },
                    { 87, "EN", "User", "#(User)", "_menu" },
                    { 35, "PT", "Sub-Menu 2", "#(SubTest2)", "_menu" },
                    { 34, "PT", "Sub-Menu 1", "#(SubTest1)", "_menu" },
                    { 33, "PT", "Teste 2", "#(Test2)", "_menu" },
                    { 32, "PT", "Teste 1", "#(Test1)", "_menu" },
                    { 37, "PT", "Palavra-Passe", "#(Password)", "_loginform" },
                    { 99, "EN", "Notifications", "#(Tooltip)", "_notificationMenu" },
                    { 46, "PT", "Sim", "#(Yes)", "_modal" },
                    { 101, "EN", "From {0} to {1}", "#(FromDateToDate)", "_notificationMenu" },
                    { 58, "PT", "Opção 2", "#(opt_2)", "_dropdown" },
                    { 57, "PT", "Nenhum", "#(no_option)", "_dropdown" },
                    { 114, "EN", "Description", "#(CookieDescription)", "_cookieModal" }
                });

            migrationBuilder.InsertData(
                table: "translations",
                columns: new[] { "ID", "LanguageCode", "Text", "TokenValue", "TranslationCategoryValue" },
                values: new object[,]
                {
                    { 113, "EN", "Cookie Name", "#(CookieKey)", "_cookieModal" },
                    { 112, "EN", "Cookie used for analytics, this cookie will be disabled if no is selected.", "#(CookieAnalyticDescription)", "_cookieModal" },
                    { 111, "EN", "This page uses some cookies for analytics, select yes if you allow the use of cookies bellow.", "#(CookiesModalDescription)", "_cookieModal" },
                    { 110, "EN", "Allow Cookies", "#(CookiesModal)", "_cookieModal" },
                    { 56, "PT", "Descrição", "#(CookieDescription)", "_cookieModal" },
                    { 55, "PT", "Nome do Cookie", "#(CookieKey)", "_cookieModal" },
                    { 54, "PT", "Este cookie destina-se à análise de dados. Este cookie será desativado se seleccionar não.", "#(CookieAnalyticDescription)", "_cookieModal" },
                    { 53, "PT", "Esta página utiliza cookies para análise de informação. Seleccione sim se permite a utilização dos cookies a baixo.", "#(CookiesModalDescription)", "_cookieModal" },
                    { 52, "PT", "Aceitar Cookies", "#(CookiesModal)", "_cookieModal" },
                    { 100, "EN", "Notification List", "#(NotificationHeader)", "_notificationMenu" },
                    { 109, "EN", "Modal Test 2 en", "#(ModalTest2)", "_modal" },
                    { 107, "EN", "Cancel", "#(Cancel)", "_modal" },
                    { 106, "EN", "Ok", "#(Ok)", "_modal" },
                    { 105, "EN", "No", "#(No)", "_modal" },
                    { 104, "EN", "Yes", "#(Yes)", "_modal" },
                    { 51, "PT", "Modal Test 2 Pt", "#(ModalTest2)", "_modal" },
                    { 50, "PT", "Modal Test 1 Pt", "#(ModalTest1)", "_modal" },
                    { 49, "PT", "Cancelar", "#(Cancel)", "_modal" },
                    { 48, "PT", "Ok", "#(Ok)", "_modal" },
                    { 47, "PT", "Não", "#(No)", "_modal" },
                    { 31, "PT", "Sair", "#(Logout)", "_menu" },
                    { 103, "EN", "View All", "#(ViewAll)", "_notificationMenu" },
                    { 102, "EN", "There are {0} unreaded notifications from dates previous to {1}, click here to check full unread list", "#(OldUnreadedNotification)", "_notificationMenu" },
                    { 108, "EN", "Modal Test 1 en", "#(ModalTest1)", "_modal" },
                    { 30, "PT", "Administração", "#(Administration)", "_menu" },
                    { 84, "EN", "Sat", "#(Sat)", "_datePicker" },
                    { 86, "EN", "KRF", "#(krf)", "_brand" },
                    { 17, "PT", "Setembro", "#(September)", "_datePicker" },
                    { 16, "PT", "Agosto", "#(August)", "_datePicker" },
                    { 15, "PT", "Julho", "#(July)", "_datePicker" },
                    { 14, "PT", "Junho", "#(June)", "_datePicker" },
                    { 13, "PT", "Maio", "#(May)", "_datePicker" },
                    { 12, "PT", "Abril", "#(April)", "_datePicker" },
                    { 11, "PT", "Março", "#(March)", "_datePicker" },
                    { 10, "PT", "Fevereiro", "#(February)", "_datePicker" },
                    { 9, "PT", "Janeiro", "#(January)", "_datePicker" },
                    { 66, "EN", "Component Test Page", "#(TestPage Title)", "_TestPage" },
                    { 8, "PT", "Página de Teste de Componentes", "#(TestPage Title)", "_TestPage" },
                    { 65, "EN", "Remove", "#(remove)", "_tableText" },
                    { 64, "EN", "Edit", "#(edit)", "_tableText" },
                    { 7, "PT", "Remover", "#(remove)", "_tableText" },
                    { 6, "PT", "Editar", "#(edit)", "_tableText" }
                });

            migrationBuilder.InsertData(
                table: "translations",
                columns: new[] { "ID", "LanguageCode", "Text", "TokenValue", "TranslationCategoryValue" },
                values: new object[,]
                {
                    { 63, "EN", "Cancel", "#(Cancel)", "_generic" },
                    { 62, "EN", "View details", "#(cardDetails)", "_generic" },
                    { 61, "EN", "Click at the button to return to homepage.", "#(goBackToHomeToolTip)", "_generic" },
                    { 60, "EN", "Go back to Homepage", "#(goBackToHome)", "_generic" },
                    { 59, "EN", "Loading!", "#(loadingText)", "_generic" },
                    { 5, "PT", "Cancelar", "#(Cancel)", "_generic" },
                    { 4, "PT", "Ver detalhes", "#(cardDetails)", "_generic" },
                    { 3, "PT", "Carregue no botão para retomar para a homepage.", "#(goBackToHomeToolTip)", "_generic" },
                    { 2, "PT", "Voltar para Homepage", "#(goBackToHome)", "_generic" },
                    { 1, "PT", "A Carregar!", "#(loadingText)", "_generic" },
                    { 18, "PT", "Outubro", "#(October)", "_datePicker" },
                    { 19, "PT", "Novembro", "#(November)", "_datePicker" },
                    { 20, "PT", "Dezembro", "#(December)", "_datePicker" },
                    { 21, "PT", "Seg", "#(Mon)", "_datePicker" },
                    { 28, "PT", "KRF", "#(krf)", "_brand" },
                    { 85, "EN", "Sun", "#(Sun)", "_datePicker" },
                    { 115, "EN", "None", "#(no_option)", "_dropdown" },
                    { 83, "EN", "Fri", "#(Fri)", "_datePicker" },
                    { 82, "EN", "Thu", "#(Thu)", "_datePicker" },
                    { 81, "EN", "Wed", "#(Wed)", "_datePicker" },
                    { 80, "EN", "Tue", "#(Tue)", "_datePicker" },
                    { 79, "EN", "Mon", "#(Mon)", "_datePicker" },
                    { 78, "EN", "December", "#(December)", "_datePicker" },
                    { 77, "EN", "November", "#(November)", "_datePicker" },
                    { 76, "EN", "October", "#(October)", "_datePicker" },
                    { 75, "EN", "September", "#(September)", "_datePicker" },
                    { 29, "PT", "Utilizador", "#(User)", "_menu" },
                    { 74, "EN", "August", "#(August)", "_datePicker" },
                    { 72, "EN", "June", "#(June)", "_datePicker" },
                    { 71, "EN", "May", "#(May)", "_datePicker" },
                    { 70, "EN", "April", "#(April)", "_datePicker" },
                    { 69, "EN", "March", "#(March)", "_datePicker" },
                    { 68, "EN", "February", "#(February)", "_datePicker" },
                    { 67, "EN", "January", "#(January)", "_datePicker" },
                    { 27, "PT", "Dom", "#(Sun)", "_datePicker" },
                    { 26, "PT", "Sab", "#(Sat)", "_datePicker" },
                    { 25, "PT", "Sex", "#(Fri)", "_datePicker" },
                    { 24, "PT", "Qui", "#(Thu)", "_datePicker" },
                    { 23, "PT", "Qua", "#(Wed)", "_datePicker" },
                    { 22, "PT", "Ter", "#(Tue)", "_datePicker" },
                    { 73, "EN", "July", "#(July)", "_datePicker" },
                    { 116, "EN", "Option 2", "#(opt_2)", "_dropdown" }
                });

            migrationBuilder.CreateIndex(
                name: "IN_ErrorTranslation_ErrorCode_LanguageCode",
                table: "error_translations",
                columns: new[] { "Code", "LanguageCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_error_translations_LanguageCode",
                table: "error_translations",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IN_TRANSLATIONS_LanguageCode_TokenValue_TranslationCategoryValue",
                table: "translations",
                columns: new[] { "LanguageCode", "TokenValue", "TranslationCategoryValue" },
                unique: true);

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
                name: "error_translations");

            migrationBuilder.DropTable(
                name: "homepages");

            migrationBuilder.DropTable(
                name: "translations");

            migrationBuilder.DropTable(
                name: "error_code");

            migrationBuilder.DropTable(
                name: "languages");

            migrationBuilder.DropTable(
                name: "tokens");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
