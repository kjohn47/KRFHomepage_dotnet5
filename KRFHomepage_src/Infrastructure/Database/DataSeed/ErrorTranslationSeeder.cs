namespace KRFHomepage.Infrastructure.Database.DataSeed
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using KRFHomepage.Domain.Database.Translations;

    public static class ErrorTranslationSeeder
    {
        public static void Seed(EntityTypeBuilder<ErrorTranslation> entity)
        {
            entity.HasData(new[] {
                new ErrorTranslation {
                    ID = 1,
                    LanguageCode = "PT",
                    Title = "Erro Genérico",
                    Message = "Erro Genérico",
                    Code = "GenericError"
                },
                new ErrorTranslation {
                    ID = 2,
                    LanguageCode = "PT",
                    Title = "Página não encontrada",
                    Message = "Página não encontrada",
                    Code = "PageNotFound"
                },
                new ErrorTranslation {
                    ID = 3,
                    LanguageCode = "PT",
                    Title = "Apenas Administrador",
                    Message = "Página só se encontrada disponível para administração!",
                    Code = "AdminOnlyError"
                },
                new ErrorTranslation {
                    ID = 4,
                    LanguageCode = "PT",
                    Title = "Chamada a serviço abortada",
                    Message = "A chamada ao serviço foi abortada ou terminou o tempo de espera",
                    Code = "AbortError"
                },
                new ErrorTranslation {
                    ID = 5,
                    LanguageCode = "EN",
                    Title = "Generic Error",
                    Message = "Generic Error",
                    Code = "GenericError"
                },
                new ErrorTranslation {
                    ID = 6,
                    LanguageCode = "EN",
                    Title = "Page not found",
                    Message = "Page not found",
                    Code = "PageNotFound"
                },
                new ErrorTranslation {
                    ID = 7,
                    LanguageCode = "EN",
                    Title = "Administrator Only",
                    Message = "This page is only available for administration!",
                    Code = "AdminOnlyError"
                },
                new ErrorTranslation {
                    ID = 8,
                    LanguageCode = "EN",
                    Title = "Aborted service call",
                    Message = "The call to service was aborted or service Timed Out",
                    Code = "AbortError"
                }
            });
        }
    }
}