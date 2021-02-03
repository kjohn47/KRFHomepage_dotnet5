namespace KRFHomepage.App.DatabaseQueries
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using KRFCommon.Database;

    using KRFHomepage.Domain.Database.Translations;
    public interface ITranslationsDatabaseQuery
    {
        Task<List<TranslationCategory>> GetTranslationDataAsync(string langCode);

        Task<IEnumerable<string>> GetLanguageCodesAsync();

        Task<IQueryCommand> AddNewLanguageAsync(string langCode, string langDescription);

        Task<IQueryCommand> AddNewCategoryAsync(string categoryName);

        Task<IQueryCommand> AddNewTokenAsync(string token);

        Task<IQueryCommand> AddNewTranslationAsync(string langCode, string category, string token, string translation);

    }
}
