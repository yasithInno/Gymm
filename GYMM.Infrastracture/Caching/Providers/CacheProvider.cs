using System;

namespace GYMM.Infrastructure.Caching.Providers
{
    /// <summary>
    /// Represents the supported cache providers.
    /// </summary>
    [Serializable]
    public enum CacheProvider
    {
        /// <summary>
        /// The ASP net HTTP runtime cache provider.
        /// </summary>
        AspNetMemory,

        /// <summary>
        /// The memcached distributed memory object cache provider.
        /// </summary>
        Memcached,

        /// <summary>
        /// The Amazon ElastiCache Clustered distributed memory object cache provider.
        /// </summary>
        AmazonElastiCacheCluster,

        /// <summary>
        /// The redis networked, in-memory, key-value data store cache provider.
        /// </summary>
        Redis,

        /// <summary>
        /// The non caching cache, which provide no caching.
        /// </summary>
        NonCache
    }
}