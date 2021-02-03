namespace KRFHomepage.App.CQRS.Homepage.Query
{
    using System;
    using System.Threading.Tasks;

    using KRFCommon.CQRS.Query;
    using KRFCommon.CQRS.Common;

    using KRFHomepage.App.DatabaseQueries;
    using KRFHomepage.Domain.CQRS.Homepage.Query;    

    public class GetHomePageData : IQuery<HomePageInput, HomePageOutput>
    {
        private readonly IHomepageDatabaseQuery _homePageQuery;
        
        public GetHomePageData(Lazy<IHomepageDatabaseQuery> homePageQuery)
        {
            this._homePageQuery = homePageQuery.Value;
        }  

        public async Task<IResponseOut<HomePageOutput>> QueryAsync(HomePageInput request)
        {
            var homeDB = await this._homePageQuery.GetHomePageDataAsync(request.LangCode);
            if (homeDB != null)
            {
                var result = new HomePageOutput {
                    Title = homeDB.Title,
                    Subtitle = homeDB.SubTitle,
                    Descrption = homeDB.Description
                };
                return ResponseOut<HomePageOutput>.GenerateResult(result);
            }
            else
            {
                return ResponseOut<HomePageOutput>.GenerateFault(new ErrorOut(System.Net.HttpStatusCode.NotFound, "Could not retrieve requested homepage", ResponseErrorType.Database));
            }
        }
    }
}
