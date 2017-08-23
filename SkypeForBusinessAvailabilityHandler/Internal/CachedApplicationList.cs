using System;
using System.Collections.Generic;
using SkypeForBusinessAvailabilityHandler.Core;

namespace SkypeForBusinessAvailabilityHandler.Internal
{
    /// <inheritdoc cref="IApplicationList" />
    public class CachedApplicationList : CachedValue<List<string>>, IApplicationList
    {
        private readonly IAppConfiguration _appConfiguration;
        /// <summary>
        /// Constructor of the class
        /// </summary>
        /// <param name="appConfiguration"></param>
        public CachedApplicationList(IAppConfiguration appConfiguration)
        {
            _appConfiguration = appConfiguration ?? throw new ArgumentNullException(nameof(appConfiguration));
        }

        /// <inheritdoc />
        protected override List<string> NonCachedValue
        {
            get
            {
                var list = new List<string>();
                var applications = _appConfiguration.ValueFor("applications");
                applications = applications.ToLower().Replace(".exe", "");
                if (applications.Contains(";"))
                {
                    list.AddRange(applications.Split(';'));
                }
                else
                {
                    list.Add(applications);
                }

                return list;
            }
        }
    }
}