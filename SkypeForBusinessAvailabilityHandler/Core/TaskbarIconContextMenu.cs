using System;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.IconPacks;

namespace SkypeForBusinessAvailabilityHandler.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class TaskbarIconContextMenu : ITaskbarIconContextMenu
    {
        private readonly IMainWindowInstance _mainWindowInstance;
        private readonly ITaskbarIconInstance _taskbarIconInstance;

        /// <summary>
        ///     Constructor of the class
        /// </summary>
        public TaskbarIconContextMenu(IMainWindowInstance mainWindowInstance, ITaskbarIconInstance taskbarIconInstance)
        {
            if (mainWindowInstance == null)
            {
                throw new ArgumentNullException(nameof(mainWindowInstance));
            }
            if (taskbarIconInstance == null)
            {
                throw new ArgumentNullException(nameof(taskbarIconInstance));
            }
            _mainWindowInstance = mainWindowInstance;
            _taskbarIconInstance = taskbarIconInstance;
        }

        public ContextMenu Value
        {
            get
            {
                var contextMenu = new ContextMenu();


                var restoreApplication = new MenuItem();
                restoreApplication.Header = "Restore application";
                restoreApplication.Icon = new PackIconMaterial
                                          {
                                              Kind = PackIconMaterialKind.WindowRestore
                                          };
                restoreApplication.Click += ContextMenuItemRestoreClick;

                var closeApplication = new MenuItem();
                closeApplication.Header = "Close application";
                closeApplication.Icon = new PackIconMaterial
                                        {
                                            Kind = PackIconMaterialKind.Power
                                        };
                closeApplication.Click += ContextMenuItemCloseClick;

                //contextMenu.Items.Add(new Separator());
                //contextMenu.Items.Add(restoreApplication);
                contextMenu.Items.Add(closeApplication);


                return contextMenu;
            }
        }

        private void ContextMenuItemCloseClick(object sender, EventArgs e)
        {
            _taskbarIconInstance.Value.Dispose();
            _mainWindowInstance.Value.Close();
        }

        private void ContextMenuItemRestoreClick(object sender, EventArgs e)
        {
            _mainWindowInstance.Value.Show();
            _mainWindowInstance.Value.WindowState = WindowState.Normal;
        }
    }
}