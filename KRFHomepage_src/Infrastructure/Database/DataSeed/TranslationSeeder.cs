﻿namespace KRFHomepage.Infrastructure.Database.DataSeed
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
                    TranslationCategoryValue = "_tableText",
                    TokenValue = "#(edit)",
                    Text = "Editar"
                },
                new Translation
                {
                    ID = 6,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_tableText",
                    TokenValue = "#(remove)",
                    Text = "Remover"
                },
                new Translation
                {
                    ID = 7,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_TestPage",
                    TokenValue = "#(TestPage Title)",
                    Text = "Página de Teste de Componentes"
                },
                new Translation
                {
                    ID = 8,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(January)",
                    Text = "Janeiro"
                },
                new Translation
                {
                    ID = 9,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(February)",
                    Text = "Fevereiro"
                },
                new Translation
                {
                    ID = 10,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(March)",
                    Text = "Março"
                },
                new Translation
                {
                    ID = 11,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(April)",
                    Text = "Abril"
                },
                new Translation
                {
                    ID = 12,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(May)",
                    Text = "Maio"
                },
                new Translation
                {
                    ID = 13,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(June)",
                    Text = "Junho"
                },
                new Translation
                {
                    ID = 14,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(July)",
                    Text = "Julho"
                },
                new Translation
                {
                    ID = 15,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(August)",
                    Text = "Agosto"
                },
                new Translation
                {
                    ID = 16,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(September)",
                    Text = "Setembro"
                },
                new Translation
                {
                    ID = 17,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(October)",
                    Text = "Outubro"
                },
                new Translation
                {
                    ID = 18,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(November)",
                    Text = "Novembro"
                },
                new Translation
                {
                    ID = 19,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(December)",
                    Text = "Dezembro"
                },
                new Translation
                {
                    ID = 20,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(Mon)",
                    Text = "Seg"
                },
                new Translation
                {
                    ID = 21,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(Tue)",
                    Text = "Ter"
                },
                new Translation
                {
                    ID = 22,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(Wed)",
                    Text = "Qua"
                },
                new Translation
                {
                    ID = 23,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(Thu)",
                    Text = "Qui"
                },
                new Translation
                {
                    ID = 24,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(Fri)",
                    Text = "Sex"
                },
                new Translation
                {
                    ID = 25,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(Sat)",
                    Text = "Sab"
                },
                new Translation
                {
                    ID = 26,
                    LanguageCode = "PT",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(Sun)",
                    Text = "Dom"
                },
                new Translation
                {
                    ID = 27,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_generic",
                    TokenValue = "#(loadingText)",
                    Text = "Loading!"
                },
                new Translation
                {
                    ID = 28,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_generic",
                    TokenValue = "#(goBackToHome)",
                    Text = "Go back to Homepage"
                },
                new Translation
                {
                    ID = 29,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_generic",
                    TokenValue = "#(goBackToHomeToolTip)",
                    Text = "Click at the button to return to homepage."
                },
                new Translation
                {
                    ID = 30,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_generic",
                    TokenValue = "#(cardDetails)",
                    Text = "View details"
                },
                new Translation
                {
                    ID = 31,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_tableText",
                    TokenValue = "#(edit)",
                    Text = "Edit"
                },
                new Translation
                {
                    ID = 32,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_tableText",
                    TokenValue = "#(remove)",
                    Text = "Remove"
                },
                new Translation
                {
                    ID = 33,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_TestPage",
                    TokenValue = "#(TestPage Title)",
                    Text = "Component Test Page"
                },
                new Translation
                {
                    ID = 34,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(January)",
                    Text = "January"
                },
                new Translation
                {
                    ID = 35,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(February)",
                    Text = "February"
                },
                new Translation
                {
                    ID = 36,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(March)",
                    Text = "March"
                },
                new Translation
                {
                    ID = 37,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(April)",
                    Text = "April"
                },
                new Translation
                {
                    ID = 38,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(May)",
                    Text = "May"
                },
                new Translation
                {
                    ID = 39,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(June)",
                    Text = "June"
                },
                new Translation
                {
                    ID = 40,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(July)",
                    Text = "July"
                },
                new Translation
                {
                    ID = 41,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(August)",
                    Text = "August"
                },
                new Translation
                {
                    ID = 42,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(September)",
                    Text = "September"
                },
                new Translation
                {
                    ID = 43,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(October)",
                    Text = "October"
                },
                new Translation
                {
                    ID = 44,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(November)",
                    Text = "November"
                },
                new Translation
                {
                    ID = 45,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(December)",
                    Text = "December"
                },
                new Translation
                {
                    ID = 46,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(Mon)",
                    Text = "Mon"
                },
                new Translation
                {
                    ID = 47,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(Tue)",
                    Text = "Tue"
                },
                new Translation
                {
                    ID = 48,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(Wed)",
                    Text = "Wed"
                },
                new Translation
                {
                    ID = 49,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(Thu)",
                    Text = "Thu"
                },
                new Translation
                {
                    ID = 50,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(Fri)",
                    Text = "Fri"
                },
                new Translation
                {
                    ID = 51,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(Sat)",
                    Text = "Sat"
                },
                new Translation
                {
                    ID = 52,
                    LanguageCode = "EN",
                    TranslationCategoryValue = "_datePicker",
                    TokenValue = "#(Sun)",
                    Text = "Sun"
                }
            });
        }
    }
}