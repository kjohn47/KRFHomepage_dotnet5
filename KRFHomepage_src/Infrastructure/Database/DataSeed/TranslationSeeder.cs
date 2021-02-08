namespace KRFHomepage.Infrastructure.Database.DataSeed
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using KRFHomepage.Domain.Database.Translations;

    public static class TranslationSeeder
    {
        public static void Seed(EntityTypeBuilder<Translation> entity)
        {
            entity.HasData(new[] {
                new Translation {
                    ID = 1,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_generic",
                    TokenValue = "#(loadingText)",
                    Text = "A Carregar!"
                },
                new Translation
                {
                    ID = 2,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_generic",
                    TokenValue = "#(goBackToHome)",
                    Text = "Voltar para Homepage"
                },
                new Translation
                {
                    ID = 3,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_generic",
                    TokenValue = "#(goBackToHomeToolTip)",
                    Text = "Carregue no botão para retomar para a homepage."
                },
                new Translation
                {
                    ID = 4,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_generic",
                    TokenValue = "#(cardDetails)",
                    Text = "Ver detalhes"
                },
                new Translation
                {
                    ID = 5,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_generic",
                    TokenValue = "#(Cancel)",
                    Text = "Cancelar"
                },
                new Translation
                {
                    ID = 6,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_tableText",
                    TokenValue = "#(edit)",
                    Text = "Editar"
                },
                new Translation
                {
                    ID = 7,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_tableText",
                    TokenValue = "#(remove)",
                    Text = "Remover"
                },
                new Translation
                {
                    ID = 8,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_TestPage",
                    TokenValue = "#(TestPage Title)",
                    Text = "Página de Teste de Componentes"
                },
                new Translation
                {
                    ID = 9,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(January)",
                    Text = "Janeiro"
                },
                new Translation
                {
                    ID = 10,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(February)",
                    Text = "Fevereiro"
                },
                new Translation
                {
                    ID = 11,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(March)",
                    Text = "Março"
                },
                new Translation
                {
                    ID = 12,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(April)",
                    Text = "Abril"
                },
                new Translation
                {
                    ID = 13,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(May)",
                    Text = "Maio"
                },
                new Translation
                {
                    ID = 14,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(June)",
                    Text = "Junho"
                },
                new Translation
                {
                    ID = 15,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(July)",
                    Text = "Julho"
                },
                new Translation
                {
                    ID = 16,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(August)",
                    Text = "Agosto"
                },
                new Translation
                {
                    ID = 17,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(September)",
                    Text = "Setembro"
                },
                new Translation
                {
                    ID = 18,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(October)",
                    Text = "Outubro"
                },
                new Translation
                {
                    ID = 19,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(November)",
                    Text = "Novembro"
                },
                new Translation
                {
                    ID = 20,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(December)",
                    Text = "Dezembro"
                },
                new Translation
                {
                    ID = 21,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(Mon)",
                    Text = "Seg"
                },
                new Translation
                {
                    ID = 22,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(Tue)",
                    Text = "Ter"
                },
                new Translation
                {
                    ID = 23,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(Wed)",
                    Text = "Qua"
                },
                new Translation
                {
                    ID = 24,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(Thu)",
                    Text = "Qui"
                },
                new Translation
                {
                    ID = 25,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(Fri)",
                    Text = "Sex"
                },
                new Translation
                {
                    ID = 26,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(Sat)",
                    Text = "Sab"
                },
                new Translation
                {
                    ID = 27,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(Sun)",
                    Text = "Dom"
                },
                new Translation
                {
                    ID = 28,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_brand",
                    TokenValue = "#(krf)",
                    Text = "KRF"
                },
                new Translation
                {
                    ID = 29,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_menu",
                    TokenValue = "#(User)",
                    Text = "Utilizador"
                },
                new Translation
                {
                    ID = 30,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_menu",
                    TokenValue = "#(Administration)",
                    Text = "Administração"
                },
                new Translation
                {
                    ID = 31,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_menu",
                    TokenValue = "#(Logout)",
                    Text = "Sair"
                },
                new Translation
                {
                    ID = 32,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_menu",
                    TokenValue = "#(Test1)",
                    Text = "Teste 1"
                },
                new Translation
                {
                    ID = 33,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_menu",
                    TokenValue = "#(Test2)",
                    Text = "Teste 2"
                },
                new Translation
                {
                    ID = 34,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_menu",
                    TokenValue = "#(SubTest1)",
                    Text = "Sub-Menu 1"
                },
                new Translation
                {
                    ID = 35,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_menu",
                    TokenValue = "#(SubTest2)",
                    Text = "Sub-Menu 2"
                },
                new Translation
                {
                    ID = 36,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_loginform",
                    TokenValue = "#(Username)",
                    Text = "Utilizador"
                },
                new Translation
                {
                    ID = 37,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_loginform",
                    TokenValue = "#(Password)",
                    Text = "Palavra-Passe"
                },
                new Translation
                {
                    ID = 38,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_loginform",
                    TokenValue = "#(LoginButton)",
                    Text = "Entrar"
                },
                new Translation
                {
                    ID = 39,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_loginform",
                    TokenValue = "#(LoginDrop)",
                    Text = "Entrar"
                },
                new Translation
                {
                    ID = 40,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_loginform",
                    TokenValue = "#(NewLogin)",
                    Text = "Registar"
                },
                new Translation
                {
                    ID = 41,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_notificationMenu",
                    TokenValue = "#(Tooltip)",
                    Text = "Notificações"
                },
                new Translation
                {
                    ID = 42,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_notificationMenu",
                    TokenValue = "#(NotificationHeader)",
                    Text = "Lista de Notificações"
                },
                new Translation
                {
                    ID = 43,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_notificationMenu",
                    TokenValue = "#(FromDateToDate)",
                    Text = "De {0} até {1}"
                },
                new Translation
                {
                    ID = 44,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_notificationMenu",
                    TokenValue = "#(OldUnreadedNotification)",
                    Text = "Existem {0} notificações por ler de datas anteriores a {1}, clique aqui para vêr lista de não lidas"
                },
                new Translation
                {
                    ID = 45,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_notificationMenu",
                    TokenValue = "#(ViewAll)",
                    Text = "Ver Todas"
                },
                new Translation
                {
                    ID = 46,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_modal",
                    TokenValue = "#(Yes)",
                    Text = "Sim"
                },
                new Translation
                {
                    ID = 47,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_modal",
                    TokenValue = "#(No)",
                    Text = "Não"
                },
                new Translation
                {
                    ID = 48,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_modal",
                    TokenValue = "#(Ok)",
                    Text = "Ok"
                },
                new Translation
                {
                    ID = 49,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_modal",
                    TokenValue = "#(Cancel)",
                    Text = "Cancelar"
                },
                new Translation
                {
                    ID = 50,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_modal",
                    TokenValue = "#(ModalTest1)",
                    Text = "Modal Test 1 Pt"
                },
                new Translation
                {
                    ID = 51,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_modal",
                    TokenValue = "#(ModalTest2)",
                    Text = "Modal Test 2 Pt"
                },
                new Translation
                {
                    ID = 52,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_cookieModal",
                    TokenValue = "#(CookiesModal)",
                    Text = "Aceitar Cookies"
                },
                new Translation
                {
                    ID = 53,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_cookieModal",
                    TokenValue = "#(CookiesModalDescription)",
                    Text = "Esta página utiliza cookies para análise de informação. Seleccione sim se permite a utilização dos cookies a baixo."
                },
                new Translation
                {
                    ID = 54,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_cookieModal",
                    TokenValue = "#(CookieAnalyticDescription)",
                    Text = "Este cookie destina-se à análise de dados. Este cookie será desativado se seleccionar não."
                },
                new Translation
                {
                    ID = 55,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_cookieModal",
                    TokenValue = "#(CookieKey)",
                    Text = "Nome do Cookie"
                },
                new Translation
                {
                    ID = 56,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_cookieModal",
                    TokenValue = "#(CookieDescription)",
                    Text = "Descrição"
                },
                new Translation
                {
                    ID = 57,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_dropdown",
                    TokenValue = "#(no_option)",
                    Text = "Nenhum"
                },
                new Translation
                {
                    ID = 58,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_dropdown",
                    TokenValue = "#(opt_2)",
                    Text = "Opção 2"
                },
                new Translation
                {
                    ID = 59,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_generic",
                    TokenValue = "#(loadingText)",
                    Text = "Loading!"
                },
                new Translation
                {
                    ID = 60,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_generic",
                    TokenValue = "#(goBackToHome)",
                    Text = "Go back to Homepage"
                },
                new Translation
                {
                    ID = 61,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_generic",
                    TokenValue = "#(goBackToHomeToolTip)",
                    Text = "Click at the button to return to homepage."
                },
                new Translation
                {
                    ID = 62,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_generic",
                    TokenValue = "#(cardDetails)",
                    Text = "View details"
                },
                new Translation
                {
                    ID = 63,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_generic",
                    TokenValue = "#(Cancel)",
                    Text = "Cancel"
                },
                new Translation
                {
                    ID = 64,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_tableText",
                    TokenValue = "#(edit)",
                    Text = "Edit"
                },
                new Translation
                {
                    ID = 65,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_tableText",
                    TokenValue = "#(remove)",
                    Text = "Remove"
                },
                new Translation
                {
                    ID = 66,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_TestPage",
                    TokenValue = "#(TestPage Title)",
                    Text = "Component Test Page"
                },
                new Translation
                {
                    ID = 67,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(January)",
                    Text = "January"
                },
                new Translation
                {
                    ID = 68,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(February)",
                    Text = "February"
                },
                new Translation
                {
                    ID = 69,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(March)",
                    Text = "March"
                },
                new Translation
                {
                    ID = 70,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(April)",
                    Text = "April"
                },
                new Translation
                {
                    ID = 71,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(May)",
                    Text = "May"
                },
                new Translation
                {
                    ID = 72,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(June)",
                    Text = "June"
                },
                new Translation
                {
                    ID = 73,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(July)",
                    Text = "July"
                },
                new Translation
                {
                    ID = 74,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(August)",
                    Text = "August"
                },
                new Translation
                {
                    ID = 75,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(September)",
                    Text = "September"
                },
                new Translation
                {
                    ID = 76,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(October)",
                    Text = "October"
                },
                new Translation
                {
                    ID = 77,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(November)",
                    Text = "November"
                },
                new Translation
                {
                    ID = 78,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(December)",
                    Text = "December"
                },
                new Translation
                {
                    ID = 79,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(Mon)",
                    Text = "Mon"
                },
                new Translation
                {
                    ID = 80,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(Tue)",
                    Text = "Tue"
                },
                new Translation
                {
                    ID = 81,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(Wed)",
                    Text = "Wed"
                },
                new Translation
                {
                    ID = 82,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(Thu)",
                    Text = "Thu"
                },
                new Translation
                {
                    ID = 83,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(Fri)",
                    Text = "Fri"
                },
                new Translation
                {
                    ID = 84,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(Sat)",
                    Text = "Sat"
                },
                new Translation
                {
                    ID = 85,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(Sun)",
                    Text = "Sun"
                },
                new Translation
                {
                    ID = 86,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_brand",
                    TokenValue = "#(krf)",
                    Text = "KRF"
                },
                new Translation
                {
                    ID = 87,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_menu",
                    TokenValue = "#(User)",
                    Text = "User"
                },
                new Translation
                {
                    ID = 88,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_menu",
                    TokenValue = "#(Administration)",
                    Text = "Administration"
                },
                new Translation
                {
                    ID = 89,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_menu",
                    TokenValue = "#(Logout)",
                    Text = "Logout"
                },
                new Translation
                {
                    ID = 90,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_menu",
                    TokenValue = "#(Test1)",
                    Text = "Test 1"
                },
                new Translation
                {
                    ID = 91,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_menu",
                    TokenValue = "#(Test2)",
                    Text = "Test 2"
                },
                new Translation
                {
                    ID = 92,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_menu",
                    TokenValue = "#(SubTest1)",
                    Text = "Submenu 1"
                },
                new Translation
                {
                    ID = 93,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_menu",
                    TokenValue = "#(SubTest2)",
                    Text = "Submenu 2"
                },
                new Translation
                {
                    ID = 94,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_loginform",
                    TokenValue = "#(Username)",
                    Text = "Username"
                },
                new Translation
                {
                    ID = 95,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_loginform",
                    TokenValue = "#(Password)",
                    Text = "Password"
                },
                new Translation
                {
                    ID = 96,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_loginform",
                    TokenValue = "#(LoginButton)",
                    Text = "SignIn"
                },
                new Translation
                {
                    ID = 97,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_loginform",
                    TokenValue = "#(LoginDrop)",
                    Text = "Login"
                },
                new Translation
                {
                    ID = 98,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_loginform",
                    TokenValue = "#(NewLogin)",
                    Text = "SignUp"
                },
                new Translation
                {
                    ID = 99,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_notificationMenu",
                    TokenValue = "#(Tooltip)",
                    Text = "Notifications"
                },
                new Translation
                {
                    ID = 100,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_notificationMenu",
                    TokenValue = "#(NotificationHeader)",
                    Text = "Notification List"
                },
                new Translation
                {
                    ID = 101,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_notificationMenu",
                    TokenValue = "#(FromDateToDate)",
                    Text = "From {0} to {1}"
                },
                new Translation
                {
                    ID = 102,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_notificationMenu",
                    TokenValue = "#(OldUnreadedNotification)",
                    Text = "There are {0} unreaded notifications from dates previous to {1}, click here to check full unread list"
                },
                new Translation
                {
                    ID = 103,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_notificationMenu",
                    TokenValue = "#(ViewAll)",
                    Text = "View All"
                },
                new Translation
                {
                    ID = 104,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_modal",
                    TokenValue = "#(Yes)",
                    Text = "Yes"
                },
                new Translation
                {
                    ID = 105,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_modal",
                    TokenValue = "#(No)",
                    Text = "No"
                },
                new Translation
                {
                    ID = 106,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_modal",
                    TokenValue = "#(Ok)",
                    Text = "Ok"
                },
                new Translation
                {
                    ID = 107,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_modal",
                    TokenValue = "#(Cancel)",
                    Text = "Cancel"
                },
                new Translation
                {
                    ID = 108,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_modal",
                    TokenValue = "#(ModalTest1)",
                    Text = "Modal Test 1 en"
                },
                new Translation
                {
                    ID = 109,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_modal",
                    TokenValue = "#(ModalTest2)",
                    Text = "Modal Test 2 en"
                },
                new Translation
                {
                    ID = 110,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_cookieModal",
                    TokenValue = "#(CookiesModal)",
                    Text = "Allow Cookies"
                },
                new Translation
                {
                    ID = 111,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_cookieModal",
                    TokenValue = "#(CookiesModalDescription)",
                    Text = "This page uses some cookies for analytics, select yes if you allow the use of cookies bellow."
                },
                new Translation
                {
                    ID = 112,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_cookieModal",
                    TokenValue = "#(CookieAnalyticDescription)",
                    Text = "Cookie used for analytics, this cookie will be disabled if no is selected."
                },
                new Translation
                {
                    ID = 113,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_cookieModal",
                    TokenValue = "#(CookieKey)",
                    Text = "Cookie Name"
                },
                new Translation
                {
                    ID = 114,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_cookieModal",
                    TokenValue = "#(CookieDescription)",
                    Text = "Description"
                },
                new Translation
                {
                    ID = 115,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_dropdown",
                    TokenValue = "#(no_option)",
                    Text = "None"
                },
                new Translation
                {
                    ID = 116,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_dropdown",
                    TokenValue = "#(opt_2)",
                    Text = "Option 2"
                }
            });
        }
    }
}
