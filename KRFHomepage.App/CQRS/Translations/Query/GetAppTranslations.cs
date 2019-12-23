using KRFCommon.CQRS.Query;
using KRFHomepage.Domain.CQRS.Translations.Query;
using System.Threading.Tasks;

namespace KRFHomepage.App.CQRS.Translations.Query
{
    public class GetAppTranslations : IQuery<TranslationRequest, TranslationResponse>
    {
        public async Task<IQueryOut<TranslationResponse>> QueryAsync(TranslationRequest request)
        {
            var result = await Task.Run(() => QueryOut<TranslationResponse>.GenerateResult(new TranslationResponse()));
            return result;
        }
    }
}
