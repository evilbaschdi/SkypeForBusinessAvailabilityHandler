using System;
using System.Drawing;
using System.Reflection;
using System.Windows;

namespace SkypeForBusinessAvailabilityHandler.Core
{
    /// <summary>
    ///     Taskbar Icon configuration
    /// </summary>
    public class TaskbarIconConfiguration : ITaskbarIconConfiguration
    {
        private readonly IMainWindowInstance _mainWindowInstance;
        private readonly ITaskbarIconInstance _taskbarIconInstance;
        private readonly ITaskbarIconContextMenu _taskbarIconContextMenu;

        /// <summary>
        /// </summary>
        /// <param name="mainWindowInstance"></param>
        /// <param name="taskbarIconInstance"></param>
        /// <param name="taskbarIconContextMenu"></param>
        public TaskbarIconConfiguration(IMainWindowInstance mainWindowInstance, ITaskbarIconInstance taskbarIconInstance, ITaskbarIconContextMenu taskbarIconContextMenu)
        {
            if (mainWindowInstance == null)
            {
                throw new ArgumentNullException(nameof(mainWindowInstance));
            }
            if (taskbarIconInstance == null)
            {
                throw new ArgumentNullException(nameof(taskbarIconInstance));
            }
            if (taskbarIconContextMenu == null)
            {
                throw new ArgumentNullException(nameof(taskbarIconContextMenu));
            }


            _mainWindowInstance = mainWindowInstance;
            _taskbarIconInstance = taskbarIconInstance;
            _taskbarIconContextMenu = taskbarIconContextMenu;
        }

        /// <summary>
        ///     Constructor of the class
        /// </summary>
        public void Run()
        {
            StartMinimized();
            var filePath = Assembly.GetEntryAssembly().Location;
            if (filePath != null)
            {
                _taskbarIconInstance.Value.Icon = Icon.ExtractAssociatedIcon(filePath);
            }
            _taskbarIconInstance.Value.ContextMenu = _taskbarIconContextMenu.Value;
            //_taskbarIconInstance.Value.TrayMouseDoubleClick += TaskbarIconDoubleClick;
        }

        /// <summary>
        /// </summary>
        private void StartMinimized()
        {
            _taskbarIconInstance.Value.Visibility = Visibility.Visible;
            _mainWindowInstance.Value.Hide();
        }

        //private void TaskbarIconDoubleClick(object sender, EventArgs e)
        //{
        //    _mainWindowInstance.Value.Show();
        //    _mainWindowInstance.Value.WindowState = WindowState.Normal;
        //}
    }
}