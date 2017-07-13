using System;
using System.Collections.Generic;
using SkypeForBusinessAvailabilityHandler.Core;

namespace SkypeForBusinessAvailabilityHandler.Internal
{
    public class ApplicationList : CachedValue<List<string>>, IApplicationList
    {
        private readonly IAppConfiguration _appConfiguration;

        public ApplicationList(IAppConfiguration appConfiguration)
        {
            if (appConfiguration == null)
            {
                throw new ArgumentNullException(nameof(appConfiguration));
            }
            _appConfiguration = appConfiguration;
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