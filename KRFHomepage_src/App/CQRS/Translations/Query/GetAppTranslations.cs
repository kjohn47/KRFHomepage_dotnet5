namespace KRFHomepage.App.CQRS.Translations.Query
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;

    using KRFCommon.CQRS.Common;
    using KRFCommon.CQRS.Query;
    using KRFCommon.MemoryCache;

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
            var languageCodes = await this._memoryCache.GetCachedItemAsync( AppConstants.MemoryCacheTranslationLanguageCodeKey,
                this._memoryCacheSettings.TranslationsCacheDuration,
                () => this._translationQuery.GetLanguageCodesAsync() );

            if ( !languageCodes.Contains( request.LangCode ) )
            {
                return ResponseOut<TranslationResponse>.GenerateFault( new ErrorOut( HttpStatusCode.NotFound, 
                    "Language code does not exist on system", 
                    ResponseErrorType.Validation, 
                    nameof( request.LangCode ) ) );
            }

            var translationCacheKey = string.Format( AppConstants.MemoryCacheTranslationItemKey, request.LangCode );
            var errorTranslationCacheKey = string.Format( AppConstants.MemoryCacheErrorTranslationKey, request.LangCode );

            var translatedText = await this._memoryCache.GetCachedItemAsync( translationCacheKey, 
                this._memoryCacheSettings.TranslationsCacheDuration, 
                () => this._translationQuery.GetTranslationDataAsync( request.LangCode ) );

            var errorTranslations = await this._memoryCache.GetCachedItemAsync( errorTranslationCacheKey,
                this._memoryCacheSettings.TranslationsCacheDuration,
                () => this._translationQuery.GetErrorTranslations( request.LangCode ) );

            return ResponseOut<TranslationResponse>.GenerateResult( new TranslationResponse
            {
                Translation = translatedText,
                LanguageCodes = request.GetKeys ? languageCodes : null,
                ErrorTranslation = errorTranslations
            } );
        }
    }
}