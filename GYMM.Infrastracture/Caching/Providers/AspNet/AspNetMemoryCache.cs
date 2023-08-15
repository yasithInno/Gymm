using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Caching;

namespace GYMM.Infrastructure.Caching.Providers.AspNet
{
    /// <summary>
    /// Asp Net Memory Cache
    /// </summary>
    internal sealed class AspNetMemoryCache : Cache
    {

        #region Fields & Properties

        private static ObjectCache cache = MemoryCache.Default;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor 
        /// </summary>
        public AspNetMemoryCache() : base()
        {
        }
        #endregion

        #region Methods
        /// <summary>
        /// Add Cache
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        /// <param name="absoluteExpiration">AbsoluteExpiration</param>
        /// <param name="regionName">RegionName</param>
        public override void Add(string key, object value, DateTimeOffset absoluteExpiration, string regionName = null)
        {
            cache.Add(key, value, absoluteExpiration, regionName);
        }

        /// <summary>
        /// Cache Exists
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="regionName">Region Name</param>
        /// <returns></returns>
        public override bool Exists(string key, string regionName = null)
        {
            return cache.Get(key, regionName) != null;
        }

        /// <summary>
        /// Get Cache 
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="regionName">Region Name</param>
        /// <returns></returns>
        public override object Get(string key, string regionName = null)
        {
            return cache.Get(key, regionName);
        }

        /// <summary>
        /// Remove Remove
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="regionName">Region Name</param>
        /// <returns></returns>
        public override bool Remove(string key, string regionName = null)
        {
            return cache.Remove(key, regionName) != null;
        }

        /// <summary>
        /// Retrieve Cached Item
        /// </summary>
        /// <typeparam name="T">Type of cached item</typeparam>
        /// <param name="key">Name of cached item</param>
        /// <returns>Cached item as type</returns>
        public static T Get<T>(string key) where T : class
        {
            try
            {
                return (T)cache[key];
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Searches the one.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public override object SearchOne(string key, string regionName = null)
        {
            try
            {
                bool hasCache = cache.Any(x => x.Key.ToUpper().Contains(key.ToUpper()));
                if (hasCache)
                    return (cache.FirstOrDefault(x => x.Key.ToUpper().Contains(key.ToUpper())).Value);
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Insert value into the cache using
        /// appropriate name/value pairs
        /// </summary>
        /// <typeparam name="T">Type of cached item</typeparam>
        /// <param name="objectToCache">Item to be cached</param>
        /// <param name="key">Name of item</param>
        public static void Add<T>(T objectToCache, string key) where T : class
        {
            cache.Add(key, objectToCache, DateTime.Now.AddDays(30));
        }

        /// <summary>
        /// Get All
        /// </summary>
        /// <returns>string List</returns>
        public static List<string> GetAll()
        {
            return cache.Select(keyValuePair => keyValuePair.Key).ToList();
        }

        /// <summary>Gets all by key.</summary>
        /// <param name="keyValue">The key value.</param>
        /// <returns>Return the hashtable object.</returns>
        public override Hashtable GetAllByKey(string key, int keyIndex = 0, char splitChar = '|', string keyType = null, string regionName = null)
        {
            var listObject = cache.Where(keyValuePair => keyValuePair.Key.Contains(key)).ToList();
            Hashtable hashtableObject = new Hashtable();
            foreach (var item in listObject)
            {
                string[] splitWordsArry = item.Key.Split(splitChar);

                string[] splitkey = splitWordsArry[keyIndex].Split(new string[] { "::" }, StringSplitOptions.None);

                // TODO: Refactoring
                // get hash key
                object hashKey;
                switch(keyType)
                {
                    case "int":
                        hashKey = Convert.ToInt32(splitkey[1]);
                        break;
                    default:
                        hashKey = splitkey[1];
                        break;
                }
                hashtableObject.Add(hashKey, item.Value);
            }
            return hashtableObject;
        }

        #endregion
    }
}
