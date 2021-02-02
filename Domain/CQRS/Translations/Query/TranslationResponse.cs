namespace KRFHomepage.Domain.CQRS.Translations.Query
{
    using KRFCommon.CQRS.Query;
    using System.Collections.Generic;

    public class TranslationResponse: IQueryResponse
    {
        public Dictionary<string, Dictionary<string, string>> Translation { get; set; }

        public Dictionary<string, Dictionary<string, string>> ErrorTranslation { get; set; }

        public IEnumerable<string> LanguageCodes { get; set; }
    }
}
