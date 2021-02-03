namespace WebApi.Controllers.Homepage
{
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;

    using KRFCommon.Controller;
    using KRFCommon.CQRS.Query;

    using KRFHomepage.Domain.CQRS.Homepage.Query;

    [ApiController]
    [Route("Homepage/")]
    public class HomepageController : KRFController
    {
        [HttpGet("{langCode}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof( HomePageOutput ))]        
        public async Task<IActionResult> Get(
            [FromServices] IQuery<HomePageInput, HomePageOutput> query,
            [FromRoute] string langCode )
        {
            return await this.ExecuteAsyncQuery(new HomePageInput( langCode ), query);
        }
    }
}
