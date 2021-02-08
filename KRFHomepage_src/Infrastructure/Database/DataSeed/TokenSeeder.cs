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
                new Token { Value = "#(Sun)" },
                new Token { Value = "#(Cancel)" },
                new Token { Value = "#(krf)" },
                new Token { Value = "#(User)" },
                new Token { Value = "#(Administration)" },
                new Token { Value = "#(Logout)" },
                new Token { Value = "#(Test1)" },
                new Token { Value = "#(Test2)" },
                new Token { Value = "#(SubTest1)" },
                new Token { Value = "#(SubTest2)" },
                new Token { Value = "#(Username)" },
                new Token { Value = "#(Password)" },
                new Token { Value = "#(LoginButton)" },
                new Token { Value = "#(LoginDrop)" },
                new Token { Value = "#(NewLogin)" },
                new Token { Value = "#(Tooltip)" },
                new Token { Value = "#(NotificationHeader)" },
                new Token { Value = "#(FromDateToDate)" },
                new Token { Value = "#(OldUnreadedNotification)" },
                new Token { Value = "#(ViewAll)" },
                new Token { Value = "#(Yes)" },
                new Token { Value = "#(No)" },
                new Token { Value = "#(Ok)" },
                new Token { Value = "#(ModalTest1)" },
                new Token { Value = "#(ModalTest2)" },
                new Token { Value = "#(CookiesModal)" },
                new Token { Value = "#(CookiesModalDescription)" },
                new Token { Value = "#(CookieAnalyticDescription)" },
                new Token { Value = "#(CookieKey)" },
                new Token { Value = "#(CookieDescription)" },
                new Token { Value = "#(no_option)" },
                new Token { Value = "#(opt_2)" }
            });
        }
    }
}
