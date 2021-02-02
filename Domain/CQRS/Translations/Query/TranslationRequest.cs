namespace KRFHomepage.Domain.CQRS.Translations.Query
{
    using KRFHomepage.Domain.Constants;
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
