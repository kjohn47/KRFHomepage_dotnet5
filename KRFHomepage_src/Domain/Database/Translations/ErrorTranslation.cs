namespace KRFHomepage.Domain.Database.Translations
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using KRFHomepage.Domain.Database.Common;

    public class ErrorTranslation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }

        [ForeignKey("Code")]
        public string Code { get; set; }
        public ErrorCode ErrorCode { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        [ForeignKey("Language")]
        public string LanguageCode { get; set; }
        public Language Language { get; set; }
    }
}
