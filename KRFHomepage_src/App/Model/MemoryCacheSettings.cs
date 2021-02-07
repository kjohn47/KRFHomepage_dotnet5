namespace KRFHomepage.App.Model
{
    public class MemoryCacheSettings
    {
        private const int _defaultTranslationDuration = 120;
        private const int _defaultCleanupInterval = 10;

        public MemoryCacheSettings()
        { }

        public MemoryCacheSettings( bool initializeDefaults = false )
        {
            if ( initializeDefaults )
            {
                this._cacheCleanupInterval = new MemoryCacheCleanup
                {
                    Minutes = _defaultCleanupInterval
                };

                this._translationsCacheDuration = _defaultTranslationDuration;
            }
        }

        private MemoryCacheCleanup _cacheCleanupInterval;
        private int _translationsCacheDuration;


        public MemoryCacheSize MemoryCacheSize { get; set; }

        public MemoryCacheCleanup CacheCleanupInterval
        {
            get
            {
                return this._cacheCleanupInterval;
            }

            set
            {
                if ( value != null )
                {
                    this._cacheCleanupInterval = value;
                }
                else
                {
                    this._cacheCleanupInterval = new MemoryCacheCleanup
                    {
                        Minutes = _defaultCleanupInterval
                    };
                }
            }
        }


        public int? TranslationsCacheDuration
        {
            get
            {
                return this._translationsCacheDuration;
            }

            set
            {
                if ( value.HasValue )
                {
                    this._translationsCacheDuration = value.Value;
                }
                else
                {
                    this._translationsCacheDuration = _defaultTranslationDuration;
                }
            }
        }
    }
}
