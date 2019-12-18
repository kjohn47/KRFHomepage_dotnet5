using System.Net;
using System.Threading.Tasks;
using KRFCommon.Controller;
using KRFCommon.CQRS.Query;
using KRFHomepage.Domain.CQRS.Homepage.Query;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Homepage
{
    [ApiController]
    [Route("Homepage/")]
    public class HomepageController : KRFController
    {
        [HttpGet("GetData")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof( HomePageOutput[] ))]
        public async Task<IActionResult> GetData(
                [FromServices] IQuery<HomePageInput, HomePageOutput[]> query )
        {
            return await this.ExecuteAsyncQuery(new HomePageInput(), query);                
        }
    }
}
