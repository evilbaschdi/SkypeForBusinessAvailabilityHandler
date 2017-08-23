using System;
using System.Configuration;

namespace SkypeForBusinessAvailabilityHandler.Core
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class AppConfiguration : IAppConfiguration
    {
        /// <inheritdoc />
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