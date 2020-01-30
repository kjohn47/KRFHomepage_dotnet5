using System;
using KRFHomepage.Domain.CQRS.Sample.Query;
using System.Threading.Tasks;
using System.Linq;
using KRFCommon.CQRS.Query;
using KRFCommon.CQRS.Common;
using KRFCommon.Context;
using Newtonsoft.Json;

namespace KRFHomepage.App.CQRS.Sample.Query
{
    public class GetSampleData : IQuery<SampleInput, SampleOutput[]>
    {
        private IUserContext _userContext;
        public GetSampleData( IUserContext userContext )
        {
            this._userContext = userContext;
        }

        private readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private SampleOutput[] MakeDataResult()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new SampleOutput
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = this.Summaries[rng.Next(this.Summaries.Length)],
                UserData = this._userContext != null && this._userContext.Claim != Claims.NotLogged ? JsonConvert.SerializeObject(this._userContext) : "No User"
            })
            .ToArray();
        }

        public async Task<IResponseOut<SampleOutput[]>> QueryAsync(SampleInput request)
        {
            await Task.Yield();
            var result = this.MakeDataResult();
            return ResponseOut<SampleOutput[]>.GenerateResult(result);
            //return QueryOut<HomePageOutput[]>.GenerateFault(new ErrorOut(System.Net.HttpStatusCode.BadRequest, "Error Ocurred"));
        }
    }
}
