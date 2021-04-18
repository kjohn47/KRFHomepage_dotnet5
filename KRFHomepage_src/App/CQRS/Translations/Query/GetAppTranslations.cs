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
    using KRFHomepage.Infrastructure.Database.Queries;
    using KRFHomepage.Domain.CQRS.Translations.Query;

    public class GetAppTranslations : IQuery<TranslationRequest, TranslationResponse>
    {
        private readonly ITranslationsDatabaseQuery _translationQuery;
        private readonly IKRFMemoryCache _memoryCache;

        public GetAppTranslations( Lazy<ITranslationsDatabaseQuery> translationQuery, IKRFMemoryCache memoryCache )
        {
            this._translationQuery = translationQuery.Value;
            this._memoryCache = memoryCache;
        }

        public async Task<IResponseOut<TranslationResponse>> QueryAsync( TranslationRequest request )
        {
            var cachedLanguageCodes = await this._memoryCache.GetOrInsertCachedItemAsync( 
                AppConstants.MemoryCacheTranslationLanguageCodeKey,
                () => this._translationQuery.GetLanguageCodesAsync() );

            if ( !cachedLanguageCodes.Result.Contains( request.LangCode ) )
            {
                return ResponseOut<TranslationResponse>.GenerateFault( new ErrorOut( HttpStatusCode.NotFound, 
                    "Language code does not exist on system", 
                    ResponseErrorType.Application, 
                    nameof( request.LangCode ),
                    AppConstants.InvalidLanguageErrCode ) );
            }

            var translationCacheKey = string.Format( AppConstants.MemoryCacheTranslationItemKey, request.LangCode );
            var errorTranslationCacheKey = string.Format( AppConstants.MemoryCacheErrorTranslationKey, request.LangCode );

            var cachedTranslatedText = await this._memoryCache.GetOrInsertCachedItemAsync( 
                translationCacheKey,
                AppConstants.MemoryCacheTranslationSettingsKey,
                () => this._translationQuery.GetTranslationDataAsync( request.LangCode ) );

            var cachedErrorTranslations = await this._memoryCache.GetOrInsertCachedItemAsync( 
                errorTranslationCacheKey,
                AppConstants.MemoryCacheTranslationSettingsKey,
                () => this._translationQuery.GetErrorTranslations( request.LangCode ) );

            return ResponseOut<TranslationResponse>.GenerateResult( new TranslationResponse
            {
                Translation = cachedTranslatedText.Result,
                LanguageCodes = request.GetKeys ? cachedLanguageCodes.Result : null,
                ErrorTranslation = cachedErrorTranslations.Result
            } );
        }
    }
}