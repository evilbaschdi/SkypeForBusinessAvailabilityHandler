using System;

namespace SkypeForBusinessAvailabilityHandler.Core
{
    /// <inheritdoc />
    public class MainWindowInstance : IMainWindowInstance
    {
        /// <summary>
        ///     Constructor of the class
        /// </summary>
        public MainWindowInstance(MainWindow mainWindow)
        {
            Value = mainWindow ?? throw new ArgumentNullException(nameof(mainWindow));
        }

        /// <inheritdoc />
        public MainWindow Value { get; }
    }
}