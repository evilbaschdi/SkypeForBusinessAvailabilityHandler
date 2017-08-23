using System;

namespace SkypeForBusinessAvailabilityHandler.Core
{
    /// <inheritdoc />
    public class AutoStartByConfiguration : IAutoStartByConfiguration
    {
        private readonly IAppConfiguration _appConfiguration;
        private readonly IAutoStart _autoStart;

        /// <summary>
        ///     Constructor of the class
        /// </summary>
        /// <param name="appConfiguration"></param>
        /// <param name="autoStart"></param>
        public AutoStartByConfiguration(IAppConfiguration appConfiguration, IAutoStart autoStart)
        {
            _appConfiguration = appConfiguration ?? throw new ArgumentNullException(nameof(appConfiguration));
            _autoStart = autoStart ?? throw new ArgumentNullException(nameof(autoStart));
        }

        /// <inheritdoc />
        public void Run()
        {
            if (_appConfiguration.ValueFor("autostart").Equals("true"))
            {
                _autoStart.Enable();
            }
            else
            {
                _autoStart.Disable();
            }
        }
    }
}