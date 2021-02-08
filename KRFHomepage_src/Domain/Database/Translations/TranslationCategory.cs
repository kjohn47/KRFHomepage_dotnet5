namespace KRFHomepage.Domain.Database.Translations
{
    using System.Collections.Generic;

    public class TranslationCategory
    {
        public string Value { get; set; }

        public virtual ICollection<Translation> Translations { get; set; }
    }
}
