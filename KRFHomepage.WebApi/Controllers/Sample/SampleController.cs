using System.Net;
using System.Threading.Tasks;
using KRFCommon.Context;
using KRFCommon.Controller;
using KRFCommon.CQRS.Query;
using KRFHomepage.Domain.CQRS.Sample.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Sample
{
    [ApiController]
    [Route("Sample/")]
    public class SampleController : KRFController
    {
        [HttpGet("GetData")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof( SampleOutput[] ))]
        public async Task<IActionResult> GetData(
                [FromServices] IQuery<SampleInput, SampleOutput[]> query )
        {
            return await this.ExecuteAsyncQuery(new SampleInput(), query);
        }

        [Authorize]
        [HttpGet("GetDataAuth")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(SampleOutput[]))]
        public async Task<IActionResult> GetDataAuth(
        [FromServices] IQuery<SampleInput, SampleOutput[]> query)
        {
            return await this.ExecuteAsyncQuery(new SampleInput(), query);
        }

        [Authorize(Policies.Admin)]
        [HttpGet("GetDataAuthAdmin")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(SampleOutput[]))]
        public async Task<IActionResult> GetDataAuthAdmin(
        [FromServices] IQuery<SampleInput, SampleOutput[]> query)
        {
            return await this.ExecuteAsyncQuery(new SampleInput(), query);
        }
    }
}
