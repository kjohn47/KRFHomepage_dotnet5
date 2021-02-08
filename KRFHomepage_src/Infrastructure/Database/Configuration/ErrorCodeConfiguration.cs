namespace KRFHomepage.Infrastructure.Database.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using KRFHomepage.Domain.Database.Translations;

    public static class ErrorCodeConfiguration
    {
        public static void Configure(EntityTypeBuilder<ErrorCode> entity)
        {
            entity.ToTable("error_code");
            entity.HasKey(t => t.Code).HasName("PK_ErrorCode");
            entity.Property(t => t.Code).IsRequired();
            entity.HasMany(t => t.ErrorTranslations).WithOne(c => c.ErrorCode);
        }
    }
}
