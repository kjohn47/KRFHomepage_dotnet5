namespace KRFHomepage.Infrastructure.Database.DataSeed
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using KRFHomepage.Domain.Database.Translations;

    public static class TranslationCategorySeeder
    {
        public static void Seed(EntityTypeBuilder<TranslationCategory> entity)
        {
            entity.HasData(new[] {
                new TranslationCategory { Value = "_generic" },
                new TranslationCategory { Value = "_tableText" },
                new TranslationCategory { Value = "_TestPage" },
                new TranslationCategory { Value = "_datePicker" },
                new TranslationCategory { Value = "_brand" },
                new TranslationCategory { Value = "_menu" },
                new TranslationCategory { Value = "_loginform" },
                new TranslationCategory { Value = "_notificationMenu" },
                new TranslationCategory { Value = "_modal" },
                new TranslationCategory { Value = "_cookieModal" },
                new TranslationCategory { Value = "_dropdown" }
            });
        }
    }
}
