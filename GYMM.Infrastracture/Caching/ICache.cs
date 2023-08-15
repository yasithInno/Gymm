using System;
using System.Collections;

namespace GYMM.Infrastructure.Caching
{
    /// <summary>
    /// Defines the functionality of a storage cache.
    /// </summary>
    public interface ICache : IDisposable
    {
        #region Indexers - Instance Member
        /// <summary>Gets or sets the <see cref="System.Object"/> with the specified name.</summary>
        /// <param name="name">The name.</param>
        /// <param name="key">The key.</param>
        /// <value>The <see cref="System.Object"/>.</value>
        /// <returns></returns>
        object this[string key, object objectToCache, string regionName = null]
        {
            get;
            set;
        }

        #endregion

        #region Methods - Instance Member

        /// <summary>Adds the specified key.</summary>
        /// <param name="key">The key.</param>
        /// <param name="objectToCache">The object to cache.</param>
        void Add(string key, object objectToCache, string regionName = null);

        /// <summary>Adds the specified key.</summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="absoluteExpiration">The absolute expiration.</param>
        /// <param name="regionName">Name of the region.</param>
        void Add(string key, object value, DateTimeOffset absoluteExpiration, string regionName = null);

        /// <summary>Existses the specified key.</summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        bool Exists(string key, string regionName = null);

        /// <summary>Removes the specified key.</summary>
        /// <param name="key">The key.</param>
        /// <param name="regionName">Name of the region.</param>
        /// <returns></returns>
        bool Remove(string key, string regionName = null);

        /// <summary>Gets the specified key.</summary>
        /// <param name="key">The key.</param>
        /// <param name="regionName">Name of the region.</param>
        /// <returns></returns>
        object Get(string key, string regionName = null);

        /// <summary>
        /// Searches the one.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="regionName">Name of the region.</param>
        /// <returns></returns>
        object SearchOne(string key, string regionName = null);


        /// <summary>Gets the specified key.</summary>
        /// <param name="key">The key.</param>
        /// <param name="regionName">Name of the region.</param>
        /// <returns></returns>
        Hashtable GetAllByKey(string key, int keyIndex = 0, char splitChar = '|', string keyType = null, string regionName = null);
        #endregion
    }
}