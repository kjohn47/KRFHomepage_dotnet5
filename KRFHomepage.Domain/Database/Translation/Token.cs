using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KRFHomepage.Domain.Database.Translation
{
    public class Token
    {
        [Key]
        public string Value { get; set; }
        public virtual ICollection<Translation> Translations { get; set; }
    }
}
