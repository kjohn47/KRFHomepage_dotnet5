namespace KRFHomepage.Infrastructure.Database.DataSeed
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using KRFHomepage.Domain.Database.Translations;

    public static class TokenSeeder
    {
        public static void Seed(EntityTypeBuilder<Token> entity)
        {
            entity.HasData(new[] {
                new Token { Value = "#(loadingText)" },
                new Token { Value = "#(goBackToHome)" },
                new Token { Value = "#(goBackToHomeToolTip)" },
                new Token { Value = "#(cardDetails)" },
                new Token { Value = "#(edit)" },
                new Token { Value = "#(remove)" },
                new Token { Value = "#(TestPage Title)" },
                new Token { Value = "#(January)" },
                new Token { Value = "#(February)" },
                new Token { Value = "#(March)" },
                new Token { Value = "#(April)" },
                new Token { Value = "#(May)" },
                new Token { Value = "#(June)" },
                new Token { Value = "#(July)" },
                new Token { Value = "#(August)" },
                new Token { Value = "#(September)" },
                new Token { Value = "#(October)" },
                new Token { Value = "#(November)" },
                new Token { Value = "#(December)" },
                new Token { Value = "#(Mon)" },
                new Token { Value = "#(Tue)" },
                new Token { Value = "#(Wed)" },
                new Token { Value = "#(Thu)" },
                new Token { Value = "#(Fri)" },
                new Token { Value = "#(Sat)" },
                new Token { Value = "#(Sun)" }
            });
        }
    }
}
