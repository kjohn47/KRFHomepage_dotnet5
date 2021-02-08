namespace KRFHomepage.Domain.Database.Homepage
{
    using KRFHomepage.Domain.Database.Common;

    public class HomePageData
    {
        public string LanguageCode { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }

        public virtual Language Language { get; set; }
    }
}
