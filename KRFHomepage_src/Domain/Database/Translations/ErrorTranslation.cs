namespace KRFHomepage.Domain.Database.Translations
{
    using KRFHomepage.Domain.Database.Common;

    public class ErrorTranslation
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string LanguageCode { get; set; }
        
        public virtual ErrorCode ErrorCode { get; set; }
        public virtual Language Language { get; set; }
    }
}
