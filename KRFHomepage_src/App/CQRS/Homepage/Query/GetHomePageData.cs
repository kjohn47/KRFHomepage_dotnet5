namespace KRFHomepage.App.CQRS.Homepage.Query
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;

    using KRFCommon.CQRS.Query;
    using KRFCommon.CQRS.Common;
    using KRFCommon.MemoryCache;

    using KRFHomepage.Infrastructure.Database.Queries;
    using KRFHomepage.Domain.CQRS.Homepage.Query;
    using KRFHomepage.App.Constants;

    public class GetHomePageData : IQuery<HomePageInput, HomePageOutput>
    {
        private readonly IHomepageDatabaseQuery _homePageQuery;
        private readonly ITranslationsDatabaseQuery _translationQuery;
        private readonly IKRFMemoryCache _memoryCache;

        public GetHomePageData( Lazy<IHomepageDatabaseQuery> homePageQuery, Lazy<ITranslationsDatabaseQuery> translationQuery, IKRFMemoryCache memoryCache )
        {
            this._homePageQuery = homePageQuery.Value;
            this._translationQuery = translationQuery.Value;
            this._memoryCache = memoryCache;
        }

        public async Task<IResponseOut<HomePageOutput>> QueryAsync( HomePageInput request )
        {
            var cachedLanguageCodes = await this._memoryCache.GetOrInsertCachedItemAsync(
                AppConstants.MemoryCacheTranslationLanguageCodeKey,
                () => this._translationQuery.GetLanguageCodesAsync() );

            if ( !cachedLanguageCodes.Result.Contains( request.LangCode ) )
            {
                return ResponseOut<HomePageOutput>.GenerateFault( new ErrorOut( HttpStatusCode.NotFound,
                    "Language code does not exist on system",
                    ResponseErrorType.Application,
                    nameof( request.LangCode ),
                    AppConstants.InvalidLanguageErrCode ) );
            }

            var key = string.Format( AppConstants.MemoryCacheHomePageItemKey, request.LangCode );
            var cachedhomeDB = await this._memoryCache.GetOrInsertCachedItemAsync(
                        key,
                        AppConstants.MemoryCacheTranslationSettingsKey,
                        () => this._homePageQuery.GetHomePageDataAsync( request.LangCode ) );

            if ( cachedhomeDB.Result == null )
            {
                return ResponseOut<HomePageOutput>.GenerateFault( new ErrorOut( HttpStatusCode.NotFound, "Could not retrieve requested homepage", ResponseErrorType.Database ) );
            }

            return ResponseOut<HomePageOutput>.GenerateResult( new HomePageOutput
            {
                Title = cachedhomeDB.Result.Title,
                Subtitle = cachedhomeDB.Result.SubTitle,
                Descrption = cachedhomeDB.Result.Description
            } );
        }
    }
}
