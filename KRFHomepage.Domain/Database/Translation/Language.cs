using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KRFHomepage.Domain.Database.Translation
{
    public class Language
    {
        [Key]
        public string Code { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Translation> Translations { get; set; }
    }
}
