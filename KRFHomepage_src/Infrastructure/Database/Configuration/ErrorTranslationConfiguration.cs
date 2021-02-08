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
            entity.HasKey(t => t.ID).HasName("PK_ErrorTranslations");
            entity.Property(t => t.ID).UseIdentityColumn();
            entity.Property(t => t.LanguageCode).IsRequired();
            entity.Property(t => t.Code).IsRequired();
            entity.Property(t => t.Title).IsRequired();
            entity.Property(t => t.Message).IsRequired();
            entity.HasOne(t => t.Language).WithMany(c => c.ErrorTranslations).HasForeignKey(t => t.LanguageCode).HasConstraintName("FK_ErrorTranslation_LanguageCode");
            entity.HasOne(t => t.ErrorCode).WithMany(c => c.ErrorTranslations).HasForeignKey(t => t.Code).HasConstraintName("FK_ErrorTranslation_ErrorCode");

            entity.HasIndex(t => new { t.Code, t.LanguageCode } ).IsUnique().HasDatabaseName("IN_ErrorTranslation_ErrorCode_LanguageCode");
        }
    }
}
