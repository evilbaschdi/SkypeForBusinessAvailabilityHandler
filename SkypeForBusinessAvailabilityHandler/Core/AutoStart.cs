using System;
using System.Reflection;
using Microsoft.Win32;

namespace SkypeForBusinessAvailabilityHandler.Core
{
    /// <inheritdoc />
    public class AutoStart : IAutoStart
    {
        private const string SubKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
        private readonly string _appName;

        /// <summary>
        ///     Constructor of the class
        /// </summary>
        /// <param name="appName"></param>
        public AutoStart(string appName)
        {
            _appName = appName ?? throw new ArgumentNullException(nameof(appName));
        }

        /// <inheritdoc />
        public void Enable()
        {
            var registryKey = Registry.CurrentUser.OpenSubKey(SubKey, true);
            var location = Assembly.GetExecutingAssembly().Location;
            registryKey?.SetValue(_appName, location);
        }


        /// <inheritdoc />
        public void Disable()
        {
            var registryKey = Registry.CurrentUser.OpenSubKey(SubKey, true);
            registryKey?.DeleteValue(_appName, false);
        }

        /// <inheritdoc />
        public bool IsEnabled
        {
            get
            {
                var registryKey = Registry.CurrentUser.OpenSubKey(SubKey, true);
                var value = registryKey?.GetValue(_appName);
                return value != null;
            }
        }
    }
}