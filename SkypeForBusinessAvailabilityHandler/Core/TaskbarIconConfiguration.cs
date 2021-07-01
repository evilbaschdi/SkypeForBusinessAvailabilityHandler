using System;
using System.Drawing;
using System.Reflection;
using System.Windows;

namespace SkypeForBusinessAvailabilityHandler.Core
{
    /// <inheritdoc />
    /// <summary>
    ///     Taskbar Icon configuration
    /// </summary>
    public class TaskbarIconConfiguration : ITaskbarIconConfiguration
    {
        private readonly IMainWindowInstance _mainWindowInstance;
        private readonly ITaskbarIconContextMenu _taskbarIconContextMenu;
        private readonly ITaskbarIconInstance _taskbarIconInstance;

        /// <summary>
        ///     Constructor of the class
        /// </summary>
        /// <param name="mainWindowInstance"></param>
        /// <param name="taskbarIconInstance"></param>
        /// <param name="taskbarIconContextMenu"></param>
        public TaskbarIconConfiguration(IMainWindowInstance mainWindowInstance, ITaskbarIconInstance taskbarIconInstance, ITaskbarIconContextMenu taskbarIconContextMenu)
        {
            _mainWindowInstance = mainWindowInstance ?? throw new ArgumentNullException(nameof(mainWindowInstance));
            _taskbarIconInstance = taskbarIconInstance ?? throw new ArgumentNullException(nameof(taskbarIconInstance));
            _taskbarIconContextMenu = taskbarIconContextMenu ?? throw new ArgumentNullException(nameof(taskbarIconContextMenu));
        }

        /// <inheritdoc />
        public void Run()
        {
            StartMinimized();
            var filePath = Assembly.GetEntryAssembly()?.Location;
            if (filePath != null)
            {
                _taskbarIconInstance.Value.Icon = Icon.ExtractAssociatedIcon(filePath);
            }

            _taskbarIconInstance.Value.ContextMenu = _taskbarIconContextMenu.Value;
            //_taskbarIconInstance.Value.TrayMouseDoubleClick += TaskbarIconDoubleClick;
        }

        private void StartMinimized()
        {
            _taskbarIconInstance.Value.Visibility = Visibility.Visible;
            _mainWindowInstance.Value.Hide();
        }
    }
}