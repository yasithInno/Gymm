using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYMM.Infrastructure.Caching
{
    /// <summary>
    /// Provides access to configuration data.
    /// </summary>
    internal static class ConfigurationData
    {

        #region Constants

        #region Constants - (configuration keys)

        #endregion

        #endregion

        #region Classes

        /// <summary>
        /// Contains plug-in names.
        /// </summary>
        private static class PluginNames
        {

            #region Constants

            /// <summary>
            /// Represents the name of the cache implementation plugin.
            /// </summary>
            public const string CacheImplementation = @"CacheImpl";

            #endregion

        }

        /// <summary>
        /// Contains section names.
        /// </summary>
        private static class SectionNames
        {
            #region Constants

            /// <summary>
            /// Represents the name of the memcached section name.
            /// </summary>
            public const string MemcachedSectionName = @"memcached";

            #endregion
        }

        #endregion

        #region Properties - Static Member

        /// <summary>
        /// Gets the name of the memcached section.
        /// </summary>
        /// <value>
        /// The name of the memcached section.
        /// </value>
        public static string MemcachedSectionName
        {
            get
            {
                return ConfigurationData.SectionNames.MemcachedSectionName;
            }
        }

        /// <summary>
        /// Gets the name of the cache implementation plugin.
        /// </summary>
        /// <value>
        /// The name of the cache implementation plugin.
        /// </value>
        public static string CacheImplementationPluginName
        {
            get
            {
                return ConfigurationData.PluginNames.CacheImplementation;
            }
        }

        #endregion
    }
}
