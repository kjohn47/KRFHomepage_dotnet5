using System.Net;
using System.Threading.Tasks;
using KRFCommon.Context;
using KRFCommon.Controller;
using KRFCommon.CQRS.Query;
using KRFHomepage.Domain.CQRS.Homepage.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Homepage
{
    [ApiController]
    [Route("Homepage/")]
    public class HomepageController : KRFController
    {
        IUserContext _user;
        public HomepageController( IUserContext userContext )
        {
            this._user = userContext;
        }

        [HttpGet("GetData")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof( HomePageOutput[] ))]
        public async Task<IActionResult> GetData(
                [FromServices] IQuery<HomePageInput, HomePageOutput[]> query )
        {
            return await this.ExecuteAsyncQuery(new HomePageInput(), query);
        }

        [Authorize]
        [HttpGet("GetDataAuth")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(HomePageOutput[]))]
        public async Task<IActionResult> GetDataAuth(
        [FromServices] IQuery<HomePageInput, HomePageOutput[]> query)
        {
            return await this.ExecuteAsyncQuery(new HomePageInput(), query);
        }

        [Authorize(Policies.Admin)]
        [HttpGet("GetDataAuthAdmin")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(HomePageOutput[]))]
        public async Task<IActionResult> GetDataAuthAdmin(
        [FromServices] IQuery<HomePageInput, HomePageOutput[]> query)
        {
            return await this.ExecuteAsyncQuery(new HomePageInput(), query);
        }
    }
}
