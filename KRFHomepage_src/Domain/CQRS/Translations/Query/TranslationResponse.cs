namespace KRFHomepage.Domain.CQRS.Translations.Query
{
    using System.Collections.Generic;

    using KRFCommon.CQRS.Query;
    using KRFHomepage.Domain.CQRS.Translations.Model;

    public class TranslationResponse: IQueryResponse
    {
        public Dictionary<string, Dictionary<string, string>> Translation { get; set; }

        public Dictionary<string, ErrorTranslationItem> ErrorTranslation { get; set; }

        public IEnumerable<string> LanguageCodes { get; set; }
    }
}
