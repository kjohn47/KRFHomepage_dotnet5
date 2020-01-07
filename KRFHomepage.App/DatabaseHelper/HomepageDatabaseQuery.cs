using KRFHomepage.Domain.Database.Homepage;
using KRFHomepage.Infrastructure.Database.DBContext;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace KRFHomepage.App.DatabaseHelper
{
    public class HomepageDatabaseQuery
    {
        private readonly HomepageDBContext _homepageDBContext;
        public HomepageDatabaseQuery(HomepageDBContext homepageDBContext)
        {
            this._homepageDBContext = homepageDBContext;
        }

        public async Task<HomePageData> GetHomePageDataAsync( string langCode )
        {
            return await this._homepageDBContext.HomePages.FirstOrDefaultAsync(q => q.LanguageCode.Equals(langCode));
        }
    }
}
