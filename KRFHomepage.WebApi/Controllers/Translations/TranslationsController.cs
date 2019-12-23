using System.Net;
using System.Threading.Tasks;
using KRFCommon.Context;
using KRFCommon.Controller;
using KRFCommon.CQRS.Query;
using KRFHomepage.Domain.CQRS.Translations.Query;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Translations
{
    [ApiController]
    [Route("Translations/")]
    public class TranslationsController : KRFController
    {
        [HttpGet("{langCode}")]

        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(TranslationResponse))]
        public async Task<IActionResult> Get(
                [FromServices] IQuery<TranslationRequest, TranslationResponse> query,
                [FromRoute] string langCode)
        {
            return await this.ExecuteAsyncQuery(new TranslationRequest( langCode ), query);            
        }
    }
}
