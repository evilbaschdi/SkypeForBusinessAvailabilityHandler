using System;
using System.Windows.Controls;
using MahApps.Metro.IconPacks;

namespace SkypeForBusinessAvailabilityHandler.Core
{
    /// <inheritdoc />
    public class TaskbarIconContextMenu : ITaskbarIconContextMenu
    {
        private readonly IMainWindowInstance _mainWindowInstance;
        private readonly ITaskbarIconInstance _taskbarIconInstance;

        /// <summary>
        ///     Constructor of the class
        /// </summary>
        public TaskbarIconContextMenu(IMainWindowInstance mainWindowInstance, ITaskbarIconInstance taskbarIconInstance)
        {
            _mainWindowInstance = mainWindowInstance ?? throw new ArgumentNullException(nameof(mainWindowInstance));
            _taskbarIconInstance = taskbarIconInstance ?? throw new ArgumentNullException(nameof(taskbarIconInstance));
        }

        /// <inheritdoc />
        public ContextMenu Value
        {
            get
            {
                var contextMenu = new ContextMenu();

                var closeApplication = new MenuItem
                                       {
                                           Header = "Close application",
                                           Icon = new PackIconMaterial
                                                  {
                                                      Kind = PackIconMaterialKind.Power
                                                  }
                                       };
                closeApplication.Click += ContextMenuItemCloseClick;
                contextMenu.Items.Add(closeApplication);

                return contextMenu;
            }
        }

        private void ContextMenuItemCloseClick(object sender, EventArgs e)
        {
            _taskbarIconInstance.Value.Dispose();
            _mainWindowInstance.Value.Close();
        }
    }
}