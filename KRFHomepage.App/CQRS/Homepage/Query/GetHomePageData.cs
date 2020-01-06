using System;
using KRFHomepage.Domain.CQRS.Homepage.Query;
using System.Threading.Tasks;
using KRFCommon.CQRS.Query;
using KRFCommon.Context;
using Newtonsoft.Json;

namespace KRFHomepage.App.CQRS.Homepage.Query
{
    public class GetHomePageData : IQuery<HomePageInput, HomePageOutput>
    {
        private string _homepageContext;
        public GetHomePageData()
        {
            this._homepageContext = "Titulo1";
        }

        public async Task<IQueryOut<HomePageOutput>> QueryAsync(HomePageInput request)
        {
            var result = new HomePageOutput
            {
                Title = this._homepageContext,
                Subtitle = this._homepageContext + " Subtitle",
                Descrption = this._homepageContext + " Description"
            };
            return await Task.Run(() => QueryOut<HomePageOutput>.GenerateResult(result));
        }
    }
}
