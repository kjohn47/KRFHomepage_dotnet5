namespace KRFHomepage.Domain.Database.Translations
{
    using System.Collections.Generic;

    public class ErrorCode
    {
        public string Code { get; set; }
        public virtual ICollection<ErrorTranslation> ErrorTranslations { get; set; }
    }
}
