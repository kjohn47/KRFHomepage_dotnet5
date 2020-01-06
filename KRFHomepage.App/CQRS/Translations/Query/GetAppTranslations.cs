using KRFCommon.CQRS.Query;
using KRFHomepage.Domain.CQRS.Translations.Query;
using KRFHomepage.Domain.Database.Translations;
using KRFHomepage.Infrastructure.Database.DBContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KRFHomepage.App.CQRS.Translations.Query
{
    public class GetAppTranslations : IQuery<TranslationRequest, Dictionary<string, Dictionary<string, string>>>
    {
        private readonly HomepageDBContext _translationsContext;               

        public GetAppTranslations(HomepageDBContext translationsContext )
        {
            this._translationsContext = translationsContext;
        }
        
        public async Task<IQueryOut<Dictionary<string, Dictionary<string, string>>>> QueryAsync(TranslationRequest request)
        {
            var translatedText = await this._translationsContext.Categories
                .Include(x => x.Translations)
                .Select( x => new TranslationCategory
                {
                    Value = x.Value,
                    Translations = x.Translations
                        .Where(z => z.LanguageCode.Equals(request.LangCode))
                        .ToList()
                })
                .ToListAsync();

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
            
            return await Task.Run(() => QueryOut<Dictionary<string, Dictionary<string, string>>>.GenerateResult(response));
        }   
    }
}