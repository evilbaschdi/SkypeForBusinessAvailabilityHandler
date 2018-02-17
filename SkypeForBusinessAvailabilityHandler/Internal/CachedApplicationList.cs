using System;
using System.Collections.Generic;
using EvilBaschdi.Core;
using EvilBaschdi.CoreExtended.AppHelpers;

namespace SkypeForBusinessAvailabilityHandler.Internal
{
    /// <inheritdoc cref="IApplicationList" />
    public class CachedApplicationList : CachedValue<List<string>>, IApplicationList
    {
        private readonly IAppSettingFromConfigurationManager _appSettingFromConfigurationManager;

        /// <summary>
        ///     Constructor of the class
        /// </summary>
        /// <param name="appSettingFromConfigurationManager"></param>
        public CachedApplicationList(IAppSettingFromConfigurationManager appSettingFromConfigurationManager)
        {
            _appSettingFromConfigurationManager = appSettingFromConfigurationManager ?? throw new ArgumentNullException(nameof(appSettingFromConfigurationManager));
        }

        /// <inheritdoc />
        protected override List<string> NonCachedValue
        {
            get
            {
                var list = new List<string>();
                var applications = _appSettingFromConfigurationManager.ValueFor("applications");
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