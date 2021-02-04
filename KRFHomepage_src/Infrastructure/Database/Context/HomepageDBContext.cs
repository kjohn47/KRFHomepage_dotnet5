namespace KRFHomepage.Infrastructure.Database.Context
{
    using Microsoft.EntityFrameworkCore;

    using KRFHomepage.Domain.Database.Common;
    using KRFHomepage.Domain.Database.Homepage;
    using KRFHomepage.Domain.Database.Translations;
    using KRFHomepage.Infrastructure.Database.Configuration;
    using KRFHomepage.Infrastructure.Database.DataSeed;

    public class HomepageDBContext : DbContext
    {
        public HomepageDBContext(DbContextOptions options) : base(options)
        {
        }

        //// Database Tables class ////
        public DbSet<Language> Languages { get; set; }
        public DbSet<HomePageData> HomePages { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<TranslationCategory> Categories { get; set; }
        public DbSet<Translation> Translations { get; set; }
        public DbSet<ErrorCode> ErrorCodes { get; set; }
        public DbSet<ErrorTranslation> ErrorTranslations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>(l =>
            {
                CommonConfiguration.Configure(l);
                CommonSeeder.Seed(l);
            });

            modelBuilder.Entity<HomePageData>(h =>
            {
                HomepageConfiguration.Configure(h);
                HomepageSeeder.Seed(h);
            });

            modelBuilder.Entity<TranslationCategory>(t =>
            {
                TranslationCategoryConfiguration.Configure(t);
                TranslationCategorySeeder.Seed(t);
            });

            modelBuilder.Entity<Token>(t =>
            {
                TokenConfiguration.Configure(t);
                TokenSeeder.Seed(t);
            });

            modelBuilder.Entity<Translation>(t =>
            {
                TranslationConfiguration.Configure(t);
                TranslationSeeder.Seed(t);
            });

            modelBuilder.Entity<ErrorCode>(e =>
            {
                ErrorCodeConfiguration.Configure(e);
                //ErrorCodeSeeder.Seed(e);
            });

            modelBuilder.Entity<ErrorTranslation>(e =>
            {
                ErrorTranslationConfiguration.Configure(e);
                //ErrorTranslationSeeder.Seed(e);
            });
        }
    }
}
