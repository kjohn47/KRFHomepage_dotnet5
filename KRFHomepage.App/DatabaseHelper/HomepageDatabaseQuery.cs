using KRFHomepage.Domain.Database.Homepage;
using KRFHomepage.Infrastructure.Database.DBContext;
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
            return await Task.Run(() => this._homepageDBContext.HomePages.FirstOrDefault(q => q.LanguageCode.Equals(langCode)));
        }
    }
}
