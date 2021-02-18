namespace WebApi.Controllers
{
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;

    using KRFCommon.Controller;
    using KRFCommon.CQRS.Query;

    using KRFHomepage.Domain.CQRS.Homepage.Query;
    using KRFHomepage.Domain.CQRS.Translations.Query;
    using Microsoft.AspNetCore.Authorization;

    [ApiController]
    [Route( "homepage/" )]
    public class HomepageController : KRFController
    {
        [HttpGet( "home/{langCode}" )]
        [ProducesResponseType( ( int ) HttpStatusCode.OK, Type = typeof( HomePageOutput ) )]
        public async Task<IActionResult> Get(
            [FromServices] IQuery<HomePageInput, HomePageOutput> query,
            [FromRoute] string langCode )
        {
            return await this.ExecuteAsyncQuery( new HomePageInput( langCode ), query );
        }

        [HttpGet( "translations" )]
        [ProducesResponseType( ( int ) HttpStatusCode.OK, Type = typeof( TranslationResponse ) )]
        public async Task<IActionResult> GetDefault(
        [FromServices] IQuery<TranslationRequest, TranslationResponse> query )
        {
            return await this.ExecuteAsyncQuery( new TranslationRequest( null ), query );
        }

        [HttpGet( "translations/{langCode}" )]
        [ProducesResponseType( ( int ) HttpStatusCode.OK, Type = typeof( TranslationResponse ) )]
        public async Task<IActionResult> Get(
        [FromServices] IQuery<TranslationRequest, TranslationResponse> query,
        [FromRoute] string langCode,
        [FromQuery] bool? getKeys )
        {
            return await this.ExecuteAsyncQuery( new TranslationRequest( langCode, getKeys.HasValue && getKeys.Value ), query );
        }
    }
}
