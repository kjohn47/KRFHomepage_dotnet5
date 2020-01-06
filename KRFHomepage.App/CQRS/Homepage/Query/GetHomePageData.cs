using KRFHomepage.Domain.CQRS.Homepage.Query;
using System.Threading.Tasks;
using KRFCommon.CQRS.Query;
using KRFHomepage.Infrastructure.Database.DBContext;
using System.Linq;
using KRFCommon.CQRS.Common;

namespace KRFHomepage.App.CQRS.Homepage.Query
{
    public class GetHomePageData : IQuery<HomePageInput, HomePageOutput>
    {
        private readonly HomepageDBContext _homepageDBContext;
        
        public GetHomePageData(HomepageDBContext homepageDBContext)
        {
            this._homepageDBContext = homepageDBContext;
        }   

        public async Task<IQueryOut<HomePageOutput>> QueryAsync(HomePageInput request)
        {

            var homeDB = await Task.Run(() => this._homepageDBContext.HomePages.FirstOrDefault(q => q.LanguageCode.Equals(request.LangCode)));
            if (homeDB != null)
            {
                var result = new HomePageOutput {
                    Title= homeDB.Title,
                    Subtitle = homeDB.SubTitle,
                    Descrption = homeDB.Description
                };
                return QueryOut<HomePageOutput>.GenerateResult(result);
            }
            else
            {
                return QueryOut<HomePageOutput>.GenerateFault(new ErrorOut(System.Net.HttpStatusCode.NotFound, "Could not retrieve requested homepage"));
            }
        }
    }
}
