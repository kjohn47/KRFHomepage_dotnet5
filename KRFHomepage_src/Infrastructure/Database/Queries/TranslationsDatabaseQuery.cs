namespace KRFHomepage.Infrastructure.Database.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    using KRFCommon.Database;

    using KRFHomepage.Domain.Database.Common;
    using KRFHomepage.Domain.Database.Translations;
    using KRFHomepage.Infrastructure.Database.Context;
    using KRFHomepage.Domain.CQRS.Translations.Model;

    public class TranslationsDatabaseQuery : ITranslationsDatabaseQuery
    {
        private readonly HomepageDBContext _homepageDBContext;
        public TranslationsDatabaseQuery( HomepageDBContext homepageDBContext )
        {
            this._homepageDBContext = homepageDBContext;
        }

        public async Task<Dictionary<string, Dictionary<string, string>>> GetTranslationDataAsync( string langCode )
        {
            var query = await this._homepageDBContext.Categories
                .Include( x => x.Translations )
                .Select( x => new
                {
                    Category = x.Value,
                    Translations = x.Translations
                        .Where( z => z.LanguageCode.Equals( langCode ) )
                        .Select( t => new
                        {
                            t.TokenValue,
                            t.Text
                        } )
                } )
                .AsNoTracking()
                .ToListAsync();

            return query.Select( x => new KeyValuePair<string, Dictionary<string, string>>(
                    x.Category,
                    x.Translations.Select( t => new KeyValuePair<string, string>
                         (
                             t.TokenValue,
                             t.Text
                         ) )
                        .ToDictionary( y => y.Key, y => y.Value )
                    ) )
                    .ToDictionary( z => z.Key, z => z.Value );
        }

        public async Task<IEnumerable<string>> GetLanguageCodesAsync()
        {
            return await this._homepageDBContext.Languages
                .AsNoTracking()
                .Select( x => x.Code )
                .ToListAsync();
        }

        public async Task<Dictionary<string, ErrorTranslationItem>> GetErrorTranslations( string langCode )
        {
            var query = await this._homepageDBContext.ErrorTranslations
                .AsNoTracking()
                .Where( x => x.LanguageCode.Equals( langCode ) )
                .Select( e => new { e.Code, e.Title, e.Message } )
                .ToListAsync();

            return query.Select( e => new KeyValuePair<string, ErrorTranslationItem>(
                    e.Code,
                    new ErrorTranslationItem
                    {
                        Title = e.Title,
                        Message = e.Message
                    }
                ) ).ToDictionary( z => z.Key, z => z.Value );
        }

        public async Task<IQueryCommand> AddNewLanguageAsync( string langCode, string langDescription )
        {
            if ( !string.IsNullOrEmpty( langCode ) && !string.IsNullOrEmpty( langDescription ) && langCode.Length == 2 )
            {
                try
                {
                    if ( await this._homepageDBContext.Languages.AnyAsync( x => x.Code.Equals( langCode ) ) )
                    {
                        return new QueryCommand { Result = QueryResultEnum.Error, ResultDescription = "Language code already exists" };
                    }

                    Language newLang = new Language
                    {
                        Code = langCode,
                        Name = langDescription
                    };

                    await this._homepageDBContext.Languages.AddAsync( newLang );
                    await this._homepageDBContext.SaveChangesAsync();
                }
                catch ( Exception ex )
                {
                    return new QueryCommand { Result = QueryResultEnum.Error, ResultDescription = ex.Message };
                }

                return new QueryCommand { Result = QueryResultEnum.Success, ResultDescription = "Success" };
            }
            else
            {
                return new QueryCommand { Result = QueryResultEnum.Error, ResultDescription = "Missing data or code is too long (max 2 char)" };
            }
        }

        public async Task<IQueryCommand> AddNewCategoryAsync( string categoryName )
        {
            if ( !string.IsNullOrEmpty( categoryName ) )
            {
                try
                {
                    if ( await this._homepageDBContext.Categories.AnyAsync( x => x.Value.Equals( categoryName ) ) )
                    {
                        return new QueryCommand { Result = QueryResultEnum.Error, ResultDescription = "Category already exists" };
                    }

                    TranslationCategory newCategory = new TranslationCategory
                    {
                        Value = categoryName
                    };

                    await this._homepageDBContext.Categories.AddAsync( newCategory );
                    await this._homepageDBContext.SaveChangesAsync();
                }
                catch ( Exception ex )
                {
                    return new QueryCommand { Result = QueryResultEnum.Error, ResultDescription = ex.Message };
                }

                return new QueryCommand { Result = QueryResultEnum.Success, ResultDescription = "Success" };
            }
            else
            {
                return new QueryCommand { Result = QueryResultEnum.Error, ResultDescription = "Missing data" };
            }
        }

        public async Task<IQueryCommand> AddNewTokenAsync( string token )
        {
            if ( !string.IsNullOrEmpty( token ) )
            {
                try
                {
                    if ( await this._homepageDBContext.Tokens.AnyAsync( x => x.Value.Equals( token ) ) )
                    {
                        return new QueryCommand { Result = QueryResultEnum.Error, ResultDescription = "Token already exists" };
                    }

                    Token newToken = new Token
                    {
                        Value = token
                    };

                    await this._homepageDBContext.Tokens.AddAsync( newToken );
                    await this._homepageDBContext.SaveChangesAsync();
                }
                catch ( Exception ex )
                {
                    return new QueryCommand { Result = QueryResultEnum.Error, ResultDescription = ex.Message };
                }

                return new QueryCommand { Result = QueryResultEnum.Success, ResultDescription = "Success" };
            }
            else
            {
                return new QueryCommand { Result = QueryResultEnum.Error, ResultDescription = "Missing data" };
            }
        }

        public async Task<IQueryCommand> AddNewTranslationAsync( string langCode, string category, string token, string translation )
        {
            if ( !string.IsNullOrEmpty( langCode ) && !string.IsNullOrEmpty( category ) && !string.IsNullOrEmpty( token ) && !string.IsNullOrEmpty( translation ) )
            {
                try
                {
                    if ( await this._homepageDBContext.Translations.AnyAsync( x => x.LanguageCode.Equals( langCode ) && x.TokenValue.Equals( token ) && x.TranslationCategoryValue.Equals( category ) ) )
                    {
                        return new QueryCommand { Result = QueryResultEnum.Error, ResultDescription = "Translation already exists" };
                    }

                    Translation newTranslation = new Translation
                    {
                        LanguageCode = langCode,
                        TranslationCategoryValue = category,
                        TokenValue = token,
                        Text = translation
                    };

                    await this._homepageDBContext.Translations.AddAsync( newTranslation );
                    await this._homepageDBContext.SaveChangesAsync();
                }
                catch ( Exception ex )
                {
                    return new QueryCommand { Result = QueryResultEnum.Error, ResultDescription = ex.Message };
                }

                return new QueryCommand { Result = QueryResultEnum.Success, ResultDescription = "Success" };
            }
            else
            {
                return new QueryCommand { Result = QueryResultEnum.Error, ResultDescription = "Missing data" };
            }
        }

        public void Dispose()
        {
            this._homepageDBContext.Dispose();
        }
    }
}
