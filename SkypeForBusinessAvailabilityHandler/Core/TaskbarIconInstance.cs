using System;
using Hardcodet.Wpf.TaskbarNotification;

namespace SkypeForBusinessAvailabilityHandler.Core
{
    public class TaskbarIconInstance : ITaskbarIconInstance
    {
        /// <summary>
        ///     Constructor of the class
        /// </summary>
        public TaskbarIconInstance(TaskbarIcon taskbarIcon)
        {
            if (taskbarIcon == null)
            {
                throw new ArgumentNullException(nameof(taskbarIcon));
            }
            Value = taskbarIcon;
        }

        /// <inheritdoc />
        public TaskbarIcon Value { get; }
    }
}