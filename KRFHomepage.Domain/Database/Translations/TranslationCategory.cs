using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KRFHomepage.Domain.Database.Translations
{
    public class TranslationCategory
    {
        [Key]
        public string Value { get; set; }

        public virtual ICollection<Translation> Translations { get; set; }
    }
}
