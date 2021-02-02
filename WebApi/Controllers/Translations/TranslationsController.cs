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
        [HttpGet("{langCode}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Dictionary<string, Dictionary<string, string>>))]
        public async Task<IActionResult> Get(
                [FromServices] IQuery<TranslationRequest, Dictionary<string, Dictionary<string, string>>> query,
                [FromRoute] string langCode)
        {            
            return await this.ExecuteAsyncQuery(new TranslationRequest(langCode.ToUpperInvariant()), query);
        }
    }
}
