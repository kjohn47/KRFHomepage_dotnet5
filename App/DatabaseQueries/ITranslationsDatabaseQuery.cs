namespace KRFHomepage.App.DatabaseQueries
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using KRFCommon.Database;

    using KRFHomepage.Domain.Database.Translations;
    public interface ITranslationsDatabaseQuery
    {
        Task<List<TranslationCategory>> GetTranslationDataAsync(string langCode);

        Task<QueryCommand> AddNewLanguageAsync(string langCode, string langDescription);

        Task<QueryCommand> AddNewCategoryAsync(string categoryName);

        Task<QueryCommand> AddNewTokenAsync(string token);

        Task<QueryCommand> AddNewTranslationAsync(string langCode, string category, string token, string translation);

    }
}
