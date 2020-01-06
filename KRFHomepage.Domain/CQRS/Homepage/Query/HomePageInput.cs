using KRFHomepage.Domain.Constants;

namespace KRFHomepage.Domain.CQRS.Homepage.Query
{
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
