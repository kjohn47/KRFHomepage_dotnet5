namespace KRFHomepage.App.Model
{
    using KRFCommon.MemoryCache;
    public class MemoryCacheSettings : MemoryCacheSettingsBase
    {
        private const int DefaultTranslationDuration = 120;

        private int? _translationsCacheDuration;

        public int TranslationsCacheDuration
        {
            get
            {
                if ( this._translationsCacheDuration.HasValue )
                {
                    return this._translationsCacheDuration.Value;
                }

                this._translationsCacheDuration = DefaultTranslationDuration;
                return this._translationsCacheDuration.Value;
            }

            set
            {
                this._translationsCacheDuration = value;
            }

        }
    }
}
