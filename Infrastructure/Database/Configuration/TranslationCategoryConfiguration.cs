namespace KRFHomepage.Infrastructure.Database.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using KRFHomepage.Domain.Database.Translations;

    public static class TranslationCategoryConfiguration
    {
        public static void Configure(EntityTypeBuilder<TranslationCategory> entity)
        {
            entity.ToTable("categories");
            entity.HasMany(c => c.Translations).WithOne(c => c.TranslationCategory);
        }
    }
}
