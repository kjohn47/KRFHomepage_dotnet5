namespace KRFHomepage.Infrastructure.Database.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using KRFHomepage.Domain.Database.Homepage;

    public static class HomepageConfiguration
    {
        public static void Configure(EntityTypeBuilder<HomePageData> entity)
        {
            entity.ToTable("homepages");
            entity.HasKey(h => h.LanguageCode).HasName("PK_HOMEPAGE");
            entity.Property(h => h.LanguageCode).HasMaxLength(5).IsRequired();
            entity.Property(x => x.Title).HasMaxLength(100).IsRequired();
            entity.Property(x => x.SubTitle).HasMaxLength(200).IsRequired();
            entity.Property(x => x.Description).HasMaxLength(1000).IsRequired();

            entity.HasOne(l => l.Language).WithOne(c => c.HomePageData).HasForeignKey<HomePageData>(h => h.LanguageCode).HasConstraintName("FK_HOMEPAGE_LANGUAGECODE");
        }
    }
}
