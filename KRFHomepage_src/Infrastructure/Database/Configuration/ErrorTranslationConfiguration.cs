namespace KRFHomepage.Infrastructure.Database.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using KRFHomepage.Domain.Database.Translations;

    public static class ErrorTranslationConfiguration
    {
        public static void Configure(EntityTypeBuilder<ErrorTranslation> entity)
        {
            entity.ToTable("error_translations");
            entity.Property(t => t.LanguageCode).IsRequired();
            entity.Property(t => t.ErrorCode).IsRequired();
            entity.Property(t => t.Title).IsRequired();
            entity.Property(t => t.Message).IsRequired();
            entity.HasOne(t => t.Language).WithMany(c => c.ErrorTranslations);
            entity.HasOne(t => t.ErrorCode).WithMany(c => c.ErrorTranslations);
        }
    }
}
