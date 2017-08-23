using System;
using System.Windows.Threading;

namespace SkypeForBusinessAvailabilityHandler.Internal
{
    /// <inheritdoc />
    public class DispatcherTimerInstance : IDispatcherTimerInstance
    {
        private readonly DispatcherTimer _dispatcherTimer;
        private readonly IDispatcherTimerTick _dispatcherTimerTick;

        /// <summary>
        ///     Constructor of the class
        /// </summary>
        public DispatcherTimerInstance(DispatcherTimer dispatcherTimer, IDispatcherTimerTick dispatcherTimerTick)
        {
            _dispatcherTimer = dispatcherTimer ?? throw new ArgumentNullException(nameof(dispatcherTimer));
            _dispatcherTimerTick = dispatcherTimerTick ?? throw new ArgumentNullException(nameof(dispatcherTimerTick));
        }

        /// <inheritdoc />
        public DispatcherTimer Value
        {
            get
            {
                _dispatcherTimer.Tick += _dispatcherTimerTick.RunFor;
                _dispatcherTimer.Interval = new TimeSpan(0, 0, 10);
                return _dispatcherTimer;
            }
        }
    }
}