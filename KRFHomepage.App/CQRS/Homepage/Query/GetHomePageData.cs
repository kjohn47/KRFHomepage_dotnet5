using System;
using KRFHomepage.Domain.CQRS.Homepage.Query;
using System.Threading.Tasks;
using System.Linq;
using KRFCommon.CQRS.Query;
using KRFCommon.CQRS.Common;
using KRFCommon.Context;
using Newtonsoft.Json;

namespace KRFHomepage.App.CQRS.Homepage.Query
{
    public class GetHomePageData : IQuery<HomePageInput, HomePageOutput[]>
    {
        private IUserContext _userContext;
        public GetHomePageData( IUserContext userContext )
        {
            this._userContext = userContext;
        }

        private readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private HomePageOutput[] MakeDataResult()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new HomePageOutput
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = this.Summaries[rng.Next(this.Summaries.Length)],
                UserData = this._userContext != null && this._userContext.Claim != Claims.NotLogged ? JsonConvert.SerializeObject(this._userContext) : "No User"
            })
            .ToArray();
        }

        public async Task<IQueryOut<HomePageOutput[]>> QueryAsync(HomePageInput request)
        {
            var result = await Task.Run( () => this.MakeDataResult() );
            return QueryOut<HomePageOutput[]>.GenerateResult(result);
            //return QueryOut<HomePageOutput[]>.GenerateFault(new ErrorOut(System.Net.HttpStatusCode.BadRequest, "Error Ocurred"));
        }
    }
}
