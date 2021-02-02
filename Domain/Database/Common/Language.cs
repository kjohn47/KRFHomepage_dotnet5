namespace KRFHomepage.Domain.Database.Common
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using KRFHomepage.Domain.Database.Homepage;
    using KRFHomepage.Domain.Database.Translations;
    public class Language
    {
        [Key]
        public string Code { get; set; }
        public string Name { get; set; }

        public virtual HomePageData HomePageData { get; set; }
        public virtual ICollection<Translation> Translations { get; set; }        
    }
}
