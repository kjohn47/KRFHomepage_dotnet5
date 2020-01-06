using KRFHomepage.Domain.CQRS.Homepage.Query;
using System.Threading.Tasks;
using KRFCommon.CQRS.Query;
using KRFHomepage.Infrastructure.Database.DBContext;
using System.Linq;
using KRFCommon.CQRS.Common;
using KRFHomepage.App.DatabaseHelper;

namespace KRFHomepage.App.CQRS.Homepage.Query
{
    public class GetHomePageData : IQuery<HomePageInput, HomePageOutput>
    {
        private readonly HomepageDatabaseQuery _homePageQuery;
        
        public GetHomePageData(HomepageDatabaseQuery homePageQuery)
        {
            this._homePageQuery = homePageQuery;
        }  

        public async Task<IQueryOut<HomePageOutput>> QueryAsync(HomePageInput request)
        {

            var homeDB = await this._homePageQuery.GetHomePageDataAsync(request.LangCode);
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
