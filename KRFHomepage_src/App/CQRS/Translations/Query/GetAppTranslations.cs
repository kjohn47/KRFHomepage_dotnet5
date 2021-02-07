namespace KRFHomepage.App.CQRS.Translations.Query
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using KRFCommon.CQRS.Common;
    using KRFCommon.CQRS.Query;

    using KRFHomepage.App.Constants;
    using KRFHomepage.App.DatabaseQueries;
    using KRFHomepage.App.Model;
    using KRFHomepage.Domain.CQRS.Translations.Query;

    using Microsoft.Extensions.Caching.Memory;

    public class GetAppTranslations : IQuery<TranslationRequest, TranslationResponse>
    {
        private readonly ITranslationsDatabaseQuery _translationQuery;
        private readonly MemoryCacheSettings _memoryCacheSettings;
        private readonly IMemoryCache _memoryCache;

        public GetAppTranslations( Lazy<ITranslationsDatabaseQuery> translationQuery, MemoryCacheSettings memoryCacheSettings, IMemoryCache memoryCache )
        {
            this._translationQuery = translationQuery.Value;
            this._memoryCacheSettings = memoryCacheSettings;
            this._memoryCache = memoryCache;
        }

        public async Task<IResponseOut<TranslationResponse>> QueryAsync( TranslationRequest request )
        {
            var translationCacheKey = string.Format( AppConstants.MemoryCacheTranslationItemKey, request.LangCode );
            IEnumerable<string> languageCodes = null;
            Dictionary<string, Dictionary<string, string>> response = null;

            if ( !this._memoryCache.TryGetValue( AppConstants.MemoryCacheTranslationLanguageCodeKey, out languageCodes ) )
            {
                languageCodes = await this._translationQuery.GetLanguageCodesAsync();
                this._memoryCache.Set(
                    AppConstants.MemoryCacheTranslationLanguageCodeKey,
                    languageCodes,
                    new DateTimeOffset( DateTime.Now.AddMinutes( ( double ) this._memoryCacheSettings.TranslationsCacheDuration ) ) );
            }

            if ( !languageCodes.Contains( request.LangCode ) )
            {
                return ResponseOut<TranslationResponse>.GenerateFault( new ErrorOut( System.Net.HttpStatusCode.NotFound, "Language code does not exist on sytem", ResponseErrorType.Validation ) );
            }

            if ( !this._memoryCache.TryGetValue( translationCacheKey, out response ) )
            {
                var translatedText = await this._translationQuery.GetTranslationDataAsync( request.LangCode );

                response = translatedText.Select( x => new KeyValuePair<string, Dictionary<string, string>>(
                    x.Value,
                    x.Translations.Select( t => new KeyValuePair<string, string>
                         (
                             t.TokenValue,
                             t.Text
                         ) )
                        .ToDictionary( y => y.Key, y => y.Value )
                    ) )
                    .ToDictionary( z => z.Key, z => z.Value );

                this._memoryCache.Set(
                    translationCacheKey,
                    response,
                    new DateTimeOffset( DateTime.Now.AddMinutes( ( double ) this._memoryCacheSettings.TranslationsCacheDuration ) ) );
            }

            return ResponseOut<TranslationResponse>.GenerateResult( new TranslationResponse
            {
                Translation = response,
                LanguageCodes = request.GetKeys ? languageCodes : null
            } );
        }
    }
}