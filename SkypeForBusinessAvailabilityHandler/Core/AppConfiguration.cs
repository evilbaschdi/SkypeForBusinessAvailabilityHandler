using System;
using System.Configuration;

namespace SkypeForBusinessAvailabilityHandler.Core
{
    /// <summary>
    /// </summary>
    public class AppConfiguration : IAppConfiguration
    {
        /// <summary>
        ///     Reads key value from app.config.
        /// </summary>
        public string ValueFor(string key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            return ConfigurationManager.AppSettings[key];
        }
    }
}