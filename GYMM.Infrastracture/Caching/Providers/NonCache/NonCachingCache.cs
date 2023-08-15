using System;
using System.Collections;
using System.Data;

namespace GYMM.Infrastructure.Caching.Providers.NonCache
{
    /// <summary>
    /// Represents no cache usage.
    /// </summary>
    internal sealed class NonCachingCache : Cache
    {
        #region Methods
        public override void Add(string key, object value, DateTimeOffset absoluteExpiration, string regionName = null)
        {
            throw new NotImplementedException();
        }

        public override bool Exists(string key, string regionName = null)
        {
            throw new NotImplementedException();
        }

        public override object Get(string key, string regionName = null)
        {
            throw new NotImplementedException();
        }

        public override Hashtable GetAllByKey(string key, int keyIndex = 0, char splitChar = '|', string keyType = null ,string regionName = null)
        {
            throw new NotImplementedException();
        }
        
        public override bool Remove(string key, string regionName = null)
        {
            throw new NotImplementedException();
        }

        public override object SearchOne(string key, string regionName = null)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
