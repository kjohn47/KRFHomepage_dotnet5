namespace KRFHomepage.Domain.CQRS.Translations.Query
{
    using KRFCommon.CQRS.Query;

    using KRFHomepage.Domain.Constants;
    public class TranslationRequest: IQueryRequest
    {
        public TranslationRequest( string langCode, bool getKeys = false )
        {
            if( string.IsNullOrEmpty( langCode ) )
            {
                this.LangCode = Language.PtCode;
                this.GetKeys = true;
            }
            else
            {
                this.LangCode = langCode;
                this.GetKeys = getKeys;
            }
        }

        public string LangCode { get; }

        public bool GetKeys { get; }
    }
}
