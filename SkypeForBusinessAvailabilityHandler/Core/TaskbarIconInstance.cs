using System;
using Hardcodet.Wpf.TaskbarNotification;

namespace SkypeForBusinessAvailabilityHandler.Core
{
    /// <inheritdoc />
    public class TaskbarIconInstance : ITaskbarIconInstance
    {
        /// <summary>
        ///     Constructor of the class
        /// </summary>
        public TaskbarIconInstance(TaskbarIcon taskbarIcon)
        {
            Value = taskbarIcon ?? throw new ArgumentNullException(nameof(taskbarIcon));
        }

        /// <inheritdoc />
        public TaskbarIcon Value { get; }
    }
}