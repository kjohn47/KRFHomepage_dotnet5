using System.Net;
using System.Threading.Tasks;
using KRFCommon.Context;
using KRFCommon.Controller;
using KRFCommon.CQRS.Query;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Translations
{
    [ApiController]
    [Route("Translations/")]
    public class TranslationsController : KRFController
    {
        [HttpGet("{langCode}")]

        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(string))]
        public async Task<IActionResult> Get(
                //[FromServices] IQuery<HomePageInput, HomePageOutput[]> query
                [FromRoute] string langCode)
        {
            //return await this.ExecuteAsyncQuery(new HomePageInput(), query);
            return await Task.Run(() => this.Ok(langCode));
        }
    }
}
