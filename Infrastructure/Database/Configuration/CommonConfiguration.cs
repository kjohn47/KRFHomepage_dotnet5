namespace KRFHomepage.Infrastructure.Database.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using KRFHomepage.Domain.Database.Common;

    public static class CommonConfiguration
    {
        public static void Configure(EntityTypeBuilder<Language> entity)
        {
            entity.ToTable("languages");
            entity.Property(x => x.Name).HasMaxLength(30).IsRequired();
            entity.HasMany(l => l.Translations).WithOne(c => c.Language);
            entity.HasOne(h => h.HomePageData).WithOne(c => c.Language);
        }
    }
}
