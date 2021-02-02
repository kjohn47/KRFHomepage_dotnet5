namespace KRFHomepage.Domain.Database.Translations
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class TranslationCategory
    {
        [Key]
        public string Value { get; set; }

        public virtual ICollection<Translation> Translations { get; set; }
    }
}
