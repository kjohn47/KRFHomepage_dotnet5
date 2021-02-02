namespace KRFHomepage.App.CQRS.Translations.Query
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using KRFCommon.CQRS.Common;
    using KRFCommon.CQRS.Query;

    using KRFHomepage.App.DatabaseQueries;
    using KRFHomepage.Domain.CQRS.Translations.Query;

    public class GetAppTranslations : IQuery<TranslationRequest, TranslationResponse>
    {
        private readonly ITranslationsDatabaseQuery _translationQuery;               

        public GetAppTranslations(Lazy<ITranslationsDatabaseQuery> translationQuery)
        {
            this._translationQuery = translationQuery.Value;
        }
        
        public async Task<IResponseOut<TranslationResponse>> QueryAsync(TranslationRequest request)
        {
            var translatedText = await this._translationQuery.GetTranslationDataAsync(request.LangCode);
            IEnumerable<string> languageCodes = null;

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

            if(request.GetKeys)
            {
                languageCodes = await this._translationQuery.GetLanguageCodesAsync();
            }
            
            return ResponseOut<TranslationResponse>.GenerateResult(new TranslationResponse
            {
                Translation = response,
                LanguageCodes = languageCodes
            });
        }   
    }
}