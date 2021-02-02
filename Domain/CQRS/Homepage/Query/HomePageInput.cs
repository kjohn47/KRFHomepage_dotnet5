namespace KRFHomepage.Domain.CQRS.Homepage.Query
{
    using KRFHomepage.Domain.Constants;

    public class HomePageInput
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
