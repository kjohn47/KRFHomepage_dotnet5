using KRFHomepage.Domain.Database.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KRFHomepage.Domain.Database.Translations
{
    public class Translation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }

        [ForeignKey("Token")]
        public string TokenValue { get; set; }
        public Token Token { get; set; }

        [ForeignKey("Language")]
        public string LanguageCode { get; set; }
        public Language Language { get; set; }

        [ForeignKey("TranslationCategory")]
        public string TranslationCategoryValue { get; set; }
        public TranslationCategory TranslationCategory { get; set; }

        public string Text { get; set; }

    }
}
