using System;

namespace SkypeForBusinessAvailabilityHandler.Core
{
    public class AutoStartByConfiguration : IAutoStartByConfiguration
    {
        private readonly IAppConfiguration _appConfiguration;
        private readonly IAutoStart _autoStart;

        public AutoStartByConfiguration(IAppConfiguration appConfiguration, IAutoStart autoStart)
        {
            if (appConfiguration == null)
            {
                throw new ArgumentNullException(nameof(appConfiguration));
            }
            if (autoStart == null)
            {
                throw new ArgumentNullException(nameof(autoStart));
            }
            _appConfiguration = appConfiguration;
            _autoStart = autoStart;
        }

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