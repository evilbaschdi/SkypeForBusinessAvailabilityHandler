using System;

namespace SkypeForBusinessAvailabilityHandler.Core
{
    public class MainWindowInstance : IMainWindowInstance
    {
        /// <summary>
        ///     Constructor of the class
        /// </summary>
        public MainWindowInstance(MainWindow mainWindow)
        {
            if (mainWindow == null)
            {
                throw new ArgumentNullException(nameof(mainWindow));
            }
            Value = mainWindow;
        }

        /// <inheritdoc />
        public MainWindow Value { get; }
    }
}