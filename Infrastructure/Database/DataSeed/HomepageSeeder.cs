namespace KRFHomepage.Infrastructure.Database.DataSeed
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using KRFHomepage.Domain.Database.Homepage;

    public static class HomepageSeeder
    {
        public static void Seed(EntityTypeBuilder<HomePageData> entity)
        {
            entity.HasData( new[] {
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