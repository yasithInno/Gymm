using GYMM.Infrastructure.Caching.Providers;
using GYMM.Infrastructure.Caching.Providers.AspNet;
using GYMM.Infrastructure.Caching.Providers.NonCache;

namespace GYMM.Infrastructure.Caching
{
    /// <summary>
    /// Provides functionality to get a cache instance.
    /// </summary>
    public sealed class CacheFactory
    {

        #region Fields - Static Member

        /// <summary>
        /// The synchronization lock.
        /// </summary>
        private static readonly object SyncLock = new object();

        /// <summary>
        /// The cache.
        /// </summary>
        private static ICache cache = null;

        #endregion

        #region Methods - Static Member

        #region Methods - Static Member - CacheFactory Members

        #region Methods - Static Member - CacheFactory Members (constructors)

        /// <summary>
        /// Prevents a default instance of the <see cref="CacheFactory"/> class from being created.
        /// </summary>
        private CacheFactory()
        {
        }

        #endregion

        /// <summary>
        /// Gets the cache of the requested provider.
        /// </summary>
        /// <param name="cacheProvider">The cache provider.</param>
        /// <returns>The requested cache provider.</returns>
        public static ICache Get(CacheProvider cacheProvider = CacheProvider.AspNetMemory)
        {
            if (CacheFactory.cache == null)
            {
                lock (CacheFactory.SyncLock)
                {
                    if (CacheFactory.cache == null)
                    {
                        CacheFactory.cache = CacheFactory.CreateCache(cacheProvider);
                    }
                }
            }

            return CacheFactory.cache;
        }

        /// <summary>
        /// Creates the cache for the specified provider.
        /// </summary>
        /// <param name="cacheProvider">
        /// The cache provider.
        /// </param>
        /// <returns>
        /// The requested cache provider.
        /// </returns>
        public static ICache CreateCache(CacheProvider cacheProvider)
        {
            ICache cache = null;

            switch (cacheProvider)
            {
                case CacheProvider.AspNetMemory:
                    cache = new AspNetMemoryCache();
                    break;
                case CacheProvider.NonCache:
                    cache = new NonCachingCache();
                    break;
            }

            return cache;
        }

        /// <summary>
        /// Gets the default cache.
        /// </summary>
        /// <returns>The default ASP Net Http runtime cache.</returns>
        public static ICache GetDefaultCache()
        {
            return CacheFactory.Get();
        }

        #endregion

        #endregion

    }

}