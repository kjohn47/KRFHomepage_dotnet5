namespace KRFHomepage.Domain.Database.Translations
{
    using KRFHomepage.Domain.Database.Common;

    public class Translation
    {
        public int ID { get; set; }
        public string TokenValue { get; set; }
        public string LanguageCode { get; set; }
        public string TranslationCategoryValue { get; set; }
        public string Text { get; set; }

        public virtual Token Token { get; set; }
        public virtual Language Language { get; set; }
        public virtual TranslationCategory TranslationCategory { get; set; }
    }
}
