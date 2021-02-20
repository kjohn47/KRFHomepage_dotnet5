namespace KRFHomepage.Infrastructure.Database.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using KRFCommon.Database;

    using KRFHomepage.Domain.CQRS.Translations.Model;
    using KRFHomepage.Domain.Database.Translations;
    public interface ITranslationsDatabaseQuery : IDisposable
    {
        Task<Dictionary<string, Dictionary<string, string>>> GetTranslationDataAsync( string langCode );

        Task<IEnumerable<string>> GetLanguageCodesAsync();

        Task<Dictionary<string, ErrorTranslationItem>> GetErrorTranslations( string langCode );

        Task<IQueryCommand> AddNewLanguageAsync( string langCode, string langDescription );

        Task<IQueryCommand> AddNewCategoryAsync( string categoryName );

        Task<IQueryCommand> AddNewTokenAsync( string token );

        Task<IQueryCommand> AddNewTranslationAsync( string langCode, string category, string token, string translation );

    }
}
