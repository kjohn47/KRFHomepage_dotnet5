namespace KRFHomepage.Domain.Database.Homepage
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using KRFHomepage.Domain.Database.Common;

    public class HomePageData
    {
        [Key]
        [ForeignKey("Language")]
        public string LanguageCode { get; set; }
        public Language Language { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
    }
}
