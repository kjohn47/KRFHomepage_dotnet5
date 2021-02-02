namespace WebApi.Controllers.Translations
{
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;

    using KRFCommon.Controller;
    using KRFCommon.CQRS.Query;

    using KRFHomepage.Domain.CQRS.Translations.Query;


    [ApiController]
    [Route("Translations/")]
    public class TranslationsController : KRFController
    {
        [HttpGet("")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(TranslationResponse))]
        public async Task<IActionResult> GetDefault(
        [FromServices] IQuery<TranslationRequest, TranslationResponse> query)
        {
            return await this.ExecuteAsyncQuery(new TranslationRequest(null), query);
        }

        [HttpGet("{langCode}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(TranslationResponse))]
        public async Task<IActionResult> Get(
        [FromServices] IQuery<TranslationRequest, TranslationResponse> query,
        [FromRoute] string langCode,
        [FromQuery] bool? getKeys)
        {
            return await this.ExecuteAsyncQuery(new TranslationRequest(langCode.ToUpperInvariant(), getKeys.HasValue && getKeys.Value), query);
        }
    }
}
