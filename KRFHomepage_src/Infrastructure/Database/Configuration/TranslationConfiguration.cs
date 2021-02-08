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
            entity.HasKey(t => t.ID).HasName("PK_TRANSLATIONS");
            entity.Property(t => t.ID).UseIdentityColumn();
            entity.Property(t => t.LanguageCode).HasMaxLength(5).IsRequired();
            entity.Property(t => t.TranslationCategoryValue).HasMaxLength(100).IsRequired();
            entity.Property(t => t.TokenValue).HasMaxLength(200).IsRequired();
            entity.Property(t => t.Text).HasMaxLength(1000).IsRequired();

            entity.HasOne(t => t.Language).WithMany(c => c.Translations).HasForeignKey(t => t.LanguageCode).HasConstraintName("FK_Translations_LanguageCode");
            entity.HasOne(t => t.Token).WithMany(c => c.Translations).HasForeignKey(t => t.TokenValue).HasConstraintName("FK_Translations_TokenValue");
            entity.HasOne(t => t.TranslationCategory).WithMany(c => c.Translations).HasForeignKey(t => t.TranslationCategoryValue).HasConstraintName("FK_Translations_TranslationCategoryValue");

            entity.HasIndex(t => new { t.LanguageCode, t.TokenValue, t.TranslationCategoryValue }).IsUnique().HasDatabaseName("IN_TRANSLATIONS_LanguageCode_TokenValue_TranslationCategoryValue");
        }
    }
}
