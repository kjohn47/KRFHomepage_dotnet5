namespace KRFHomepage.App.DatabaseQueries
{
    using System.Threading.Tasks; 
    using Microsoft.EntityFrameworkCore;
    
    using KRFHomepage.Domain.Database.Homepage;
    using KRFHomepage.Infrastructure.Database.Context;

    public class HomepageDatabaseQuery : IHomepageDatabaseQuery
    {
        private readonly HomepageDBContext _homepageDBContext;
        public HomepageDatabaseQuery(HomepageDBContext homepageDBContext)
        {
            this._homepageDBContext = homepageDBContext;
        }

        public async Task<HomePageData> GetHomePageDataAsync( string langCode )
        {
            return await this._homepageDBContext.HomePages.AsNoTracking().FirstOrDefaultAsync(q => q.LanguageCode.Equals(langCode));
        }
    }
}
