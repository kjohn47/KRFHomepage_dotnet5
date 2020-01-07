using KRFHomepage.Domain.Database.Common;
using Microsoft.EntityFrameworkCore;

namespace KRFHomepage.Infrastructure.Database.DBContext
{
    public partial class HomepageDBContext
    { 

        //// Database Tables class ////
        public DbSet<Language> Languages { get; set; }

        protected void CommonModelCreating(ModelBuilder modelBuilder)
        {
            //// Database Tables Configure ////
            modelBuilder.Entity<Language>(l =>
            {
                l.ToTable("languages");
                l.Property(x => x.Name).HasMaxLength(30).IsRequired();
                l.HasMany(l => l.Translations).WithOne(c => c.Language);
                l.HasOne(h => h.HomePageData).WithOne(c => c.Language);
            });

            //// Data Seed ////
            modelBuilder.Entity<Language>().HasData(new[] {
                new Language { Code = "PT", Name = "Portuguese" },
                new Language { Code = "EN", Name = "English" }
            });
        }
    }
}
