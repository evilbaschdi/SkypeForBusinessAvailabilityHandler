using System.Windows;
using System.Windows.Threading;
using SkypeForBusinessAvailabilityHandler.Core;
using SkypeForBusinessAvailabilityHandler.Internal;

namespace SkypeForBusinessAvailabilityHandler
{
    /// <inheritdoc cref="Window" />
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <inheritdoc />
        public MainWindow()
        {
            InitializeComponent();
            var dispatcherTimer = new DispatcherTimer();
            IMainWindowInstance mainWindowInstance = new MainWindowInstance(this);
            IAppConfiguration appConfiguration = new AppConfiguration();
            ITaskbarIconInstance taskbarIconInstance = new TaskbarIconInstance(AvailabilityHandlerTaskbarIcon);
            ITaskbarIconContextMenu taskbarIconContextMenu = new TaskbarIconContextMenu(mainWindowInstance, taskbarIconInstance);
            ITaskbarIconConfiguration taskbarIconConfiguration = new TaskbarIconConfiguration(mainWindowInstance, taskbarIconInstance, taskbarIconContextMenu);
            ILyncClientInstance lyncClientInstance = new CachedLyncClientInstance();
            ILyncAvailability lyncAvailability = new LyncAvailability(lyncClientInstance);
            IApplicationList applicationList = new CachedApplicationList(appConfiguration);
            IIsProcessRunning isProcessRunning = new IsProcessRunning();
            IDispatcherTimerTick dispatcherTimerTick = new DispatcherTimerTick(lyncClientInstance, lyncAvailability, applicationList, isProcessRunning);
            IDispatcherTimerInstance dispatcherTimerInstance = new DispatcherTimerInstance(dispatcherTimer, dispatcherTimerTick);
            IProcessDispatcherHandler processDispatcherHandler = new ProcessDispatcherHandler(dispatcherTimerInstance);
            IAutoStart autoStart = new AutoStart(Title);
            IAutoStartByConfiguration autoStartByConfiguration = new AutoStartByConfiguration(appConfiguration, autoStart);

            processDispatcherHandler.Run();
            taskbarIconConfiguration.Run();
            autoStartByConfiguration.Run();
        }
    }
}