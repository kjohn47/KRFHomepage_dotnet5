namespace KRFHomepage.Infrastructure.Database.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using KRFHomepage.Domain.Database.Translations;
    public static class TranslationConfiguration
    {
        public static void Configure(EntityTypeBuilder<Translation> entity)
        {
            entity.ToTable("translations");
            entity.Property(t => t.LanguageCode).IsRequired();
            entity.Property(t => t.TranslationCategoryValue).IsRequired();
            entity.Property(t => t.TokenValue).IsRequired();
            entity.Property(t => t.Text).IsRequired();
            entity.HasOne(t => t.Language).WithMany(c => c.Translations);
            entity.HasOne(t => t.Token).WithMany(c => c.Translations);
            entity.HasOne(t => t.TranslationCategory).WithMany(c => c.Translations);
        }
    }
}
