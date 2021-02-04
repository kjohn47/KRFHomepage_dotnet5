namespace KRFHomepage.Domain.Database.Translations
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ErrorCode
    {
        [Key]
        public string Code { get; set; }

        public virtual ICollection<ErrorTranslation> ErrorTranslations { get; set; }
    }
}
