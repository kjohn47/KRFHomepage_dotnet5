namespace KRFHomepage.Domain.Database.Translations
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Token
    {
        [Key]
        public string Value { get; set; }
        public virtual ICollection<Translation> Translations { get; set; }
    }
}
