using KRFHomepage.Domain.Constants;

namespace KRFHomepage.Domain.CQRS.Translations.Query
{
    public class TranslationRequest
    {
        public TranslationRequest( string langCode )
        {
            if( string.IsNullOrEmpty( langCode ) )
            {
                this.LangCode = Language.PtCode;
            }
            else
            {
                this.LangCode = langCode;
            }
        }

        public string LangCode { get; }
    }
}
