namespace KRFHomepage.Infrastructure.Database.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using KRFHomepage.Domain.Database.Common;

    public static class LanguageConfiguration
    {
        public static void Configure(EntityTypeBuilder<Language> entity)
        {
            entity.ToTable("languages");
            entity.HasKey(l => l.Code).HasName("PK_LANGUAGE");
            entity.Property(x => x.Code).HasMaxLength(5).IsRequired();
            entity.Property(x => x.Name).HasMaxLength(50).IsRequired();

            entity.HasMany(l => l.Translations).WithOne(c => c.Language);
            entity.HasOne(h => h.HomePageData).WithOne(c => c.Language);
            entity.HasMany(e => e.ErrorTranslations).WithOne(c => c.Language);
        }
    }
}
