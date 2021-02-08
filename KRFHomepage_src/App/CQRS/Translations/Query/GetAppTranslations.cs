namespace KRFHomepage.App.CQRS.Translations.Query
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;

    using KRFCommon.CQRS.Common;
    using KRFCommon.CQRS.Query;

    using KRFHomepage.App.Constants;
    using KRFHomepage.App.DatabaseQueries;
    using KRFHomepage.App.Model;
    using KRFHomepage.Domain.CQRS.Translations.Model;
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
            IEnumerable<string> languageCodes;

            if ( !this._memoryCache.TryGetValue( AppConstants.MemoryCacheTranslationLanguageCodeKey, out languageCodes ) )
            {
                languageCodes = await this._translationQuery.GetLanguageCodesAsync();
                this._memoryCache.Set(
                    AppConstants.MemoryCacheTranslationLanguageCodeKey,
                    languageCodes,
                    new DateTimeOffset( DateTime.Now.AddMinutes( this._memoryCacheSettings.TranslationsCacheDuration ) ) );
            }

            if ( !languageCodes.Contains( request.LangCode ) )
            {
                return ResponseOut<TranslationResponse>.GenerateFault( new ErrorOut( HttpStatusCode.NotFound, "Language code does not exist on system", ResponseErrorType.Validation, nameof( request.LangCode ) ) );
            }

            var translationCacheKey = string.Format( AppConstants.MemoryCacheTranslationItemKey, request.LangCode );
            var errorTranslationCacheKey = string.Format( AppConstants.MemoryCacheTranslationLanguageCodeKey, request.LangCode );

            Dictionary<string, Dictionary<string, string>> translatedText = null;
            Dictionary<string, ErrorTranslationItem> errorTranslations = null;

            if ( !this._memoryCache.TryGetValue( translationCacheKey, out translatedText ) )
            {
                translatedText = await this._translationQuery.GetTranslationDataAsync( request.LangCode );

                this._memoryCache.Set(
                    translationCacheKey,
                    translatedText,
                    new DateTimeOffset( DateTime.Now.AddMinutes( this._memoryCacheSettings.TranslationsCacheDuration ) ) );
            }

            if ( !this._memoryCache.TryGetValue( errorTranslationCacheKey, out errorTranslations ) )
            {
                errorTranslations = await this._translationQuery.GetErrorTranslations( request.LangCode );

                this._memoryCache.Set(
                    errorTranslationCacheKey,
                    errorTranslations,
                    new DateTimeOffset( DateTime.Now.AddMinutes( this._memoryCacheSettings.TranslationsCacheDuration ) ) );
            }

            return ResponseOut<TranslationResponse>.GenerateResult( new TranslationResponse
            {
                Translation = translatedText,
                LanguageCodes = request.GetKeys ? languageCodes : null,
                ErrorTranslation = errorTranslations
            } );
        }
    }
}