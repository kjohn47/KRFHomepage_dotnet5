using KRFCommon.CQRS.Common;
using KRFCommon.CQRS.Query;
using KRFHomepage.App.DatabaseHelper;
using KRFHomepage.Domain.CQRS.Translations.Query;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KRFHomepage.App.CQRS.Translations.Query
{
    public class GetAppTranslations : IQuery<TranslationRequest, Dictionary<string, Dictionary<string, string>>>
    {
        private readonly TranslationsDatabaseQuery _translationQuery;               

        public GetAppTranslations(TranslationsDatabaseQuery translationQuery)
        {
            this._translationQuery = translationQuery;
        }
        
        public async Task<IResponseOut<Dictionary<string, Dictionary<string, string>>>> QueryAsync(TranslationRequest request)
        {
            var translatedText = await this._translationQuery.GetTranslationDataAsync(request.LangCode);

            Dictionary<string, Dictionary<string, string>> response = translatedText.Select( x => new KeyValuePair<string, Dictionary<string, string>> (
                x.Value,
                x.Translations.Select(t => new KeyValuePair<string, string>
                    (
                        t.TokenValue,
                        t.Text
                    ))
                    .ToDictionary(y => y.Key, y => y.Value)
                ))
                .ToDictionary( z => z.Key, z => z.Value );
            
            return ResponseOut<Dictionary<string, Dictionary<string, string>>>.GenerateResult(response);
        }   
    }
}