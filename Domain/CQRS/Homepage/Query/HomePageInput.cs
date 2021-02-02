namespace KRFHomepage.Domain.CQRS.Homepage.Query
{
    using KRFCommon.CQRS.Query;

    using KRFHomepage.Domain.Constants;

    public class HomePageInput: IQueryRequest
    {
        public HomePageInput(string langCode)
        {
            if (string.IsNullOrEmpty(langCode))
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
