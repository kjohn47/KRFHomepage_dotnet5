using KRFHomepage.Domain.Database.Homepage;
using KRFHomepage.Domain.Database.Translations;
using KRFHomepage.Infrastructure.Database.DBContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KRFHomepage.App.DatabaseHelper
{
    public class TranslationsDatabaseQuery
    {
        private readonly HomepageDBContext _homepageDBContext;
        public TranslationsDatabaseQuery(HomepageDBContext homepageDBContext)
        {
            this._homepageDBContext = homepageDBContext;
        }

        public async Task<List<TranslationCategory>> GetTranslationDataAsync( string langCode )
        {
            return await this._homepageDBContext.Categories
                .Include(x => x.Translations)
                .Select(x => new TranslationCategory
                {
                    Value = x.Value,
                    Translations = x.Translations
                       .Where(z => z.LanguageCode.Equals(langCode))
                       .ToList()
                })
                .ToListAsync();
        }
    }
}
