using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KRFHomepage.Domain.Database.Translations;

namespace KRFHomepage.Domain.Database.Common
{
    public class Language
    {
        [Key]
        public string Code { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Translation> Translations { get; set; }
    }
}
