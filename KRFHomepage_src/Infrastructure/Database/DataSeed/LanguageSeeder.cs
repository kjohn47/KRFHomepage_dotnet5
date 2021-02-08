namespace KRFHomepage.Infrastructure.Database.DataSeed
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using KRFHomepage.Domain.Database.Common;

    public static class LanguageSeeder
    {
        public static void Seed(EntityTypeBuilder<Language> entity)
        {
            entity.HasData(new[] {
                new Language { Code = "PT", Name = "Portuguese" },
                new Language { Code = "EN", Name = "English" }
            });
        }
    }
}
