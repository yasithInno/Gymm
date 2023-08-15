using System;
using System.Collections;

namespace GYMM.Infrastructure.Caching
{
    /// <summary>
    /// Represents a cache.
    /// </summary>
    public abstract class Cache : ICache
    {
        #region Fields & Properties
        /// <summary>
        /// Gets or sets the <see cref="System.Object"/> with the specified name.
        /// </summary>
        /// <value>
        /// The <see cref="System.Object"/>.
        /// </value>
        /// <param name="name">
        /// The name of the cache.
        /// </param>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <returns>The value in the cache for the specified key.</returns>
        public object this[string key, object objectToCache,string regionName = null]
        {
            get
            {
                return this.Get(key, regionName);
            }

            set
            {
                TimeSpan expiry = TimeSpan.MaxValue;

                this.Add(key, objectToCache, regionName);
            }
        }
        #endregion

        #region Methods

        /// <summary>Adds the specified key.</summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="absoluteExpiration">The absolute expiration.</param>
        /// <param name="regionName">Name of the region.</param>
        public abstract void Add(string key, object value, DateTimeOffset absoluteExpiration, string regionName = null);

        /// <summary>Adds the specified key.</summary>
        /// <param name="key">The key.</param>
        /// <param name="objectToCache">The object to cache.</param>
        public virtual void Add(string key, object objectToCache, string regionName = null)
        {
            this.Add(key, objectToCache, DateTime.Now.AddDays(30), null);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, 
        /// releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>Existses the specified key.</summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public abstract bool Exists(string key, string regionName = null);

        /// <summary>Gets the specified key.</summary>
        /// <param name="key">The key.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public abstract object Get(string key, string regionName = null);

        /// <summary>
        /// Searches the one.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public abstract object SearchOne(string key, string regionName = null);

        /// <summary>
        /// Gets all by key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="keyIndex">Index of the key.</param>
        /// <param name="splitChar">The split character.</param>
        /// <param name="KeyType">Type of the key.</param>
        /// <param name="regionName">Name of the region.</param>
        /// <returns></returns>
        public abstract Hashtable GetAllByKey(string key, int keyIndex = 0, char splitChar = '|', string KeyType = null, string regionName = null);

        /// <summary>Removes the specified key.</summary>
        /// <param name="key">The key.</param>
        /// <param name="regionName">Name of the region.</param>
        /// <returns></returns>
        public abstract bool Remove(string key, string regionName = null);

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing">
        /// <c>true</c> to release both managed and unmanaged resources;
        /// <c>false</c> to release only unmanaged resources.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
        }
        #endregion

    }
}
