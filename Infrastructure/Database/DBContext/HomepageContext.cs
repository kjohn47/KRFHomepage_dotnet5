using KRFHomepage.Domain.Database.Common;
using KRFHomepage.Domain.Database.Homepage;
using Microsoft.EntityFrameworkCore;

namespace KRFHomepage.Infrastructure.Database.DBContext
{
    public partial class HomepageDBContext
    { 

        //// Database Tables class ////
        public DbSet<HomePageData> HomePages { get; set; }

        protected void HomepageModelCreating(ModelBuilder modelBuilder)
        {
            //// Database Tables Configure ////
            modelBuilder.Entity<HomePageData>(l =>
            {
                l.ToTable("homepages");
                l.Property(x => x.Title).HasMaxLength(100).IsRequired();
                l.Property(x => x.SubTitle).HasMaxLength(200).IsRequired();
                l.Property(x => x.Description).IsRequired();
                l.HasOne(l => l.Language).WithOne(c => c.HomePageData);
            });

            //// Data Seed ////
            modelBuilder.Entity<HomePageData>().HasData(new[] {
                new HomePageData { 
                    LanguageCode = "PT", 
                    Title = "KJohn React Framework", 
                    SubTitle = "A página principal do KRF com microserviços", 
                    Description = "Bem Vindo ao KRF, isto é uma framework react para fazer desenvolvimento divertido :)"
                },
                new HomePageData { 
                    LanguageCode = "EN", 
                    Title = "KJohn React Framework", 
                    SubTitle = "The KRF homepage with microservices", 
                    Description = "Welcome to KRF, this is a react framework to make some fun dev :)"
                }
            });
        }
    }
}
