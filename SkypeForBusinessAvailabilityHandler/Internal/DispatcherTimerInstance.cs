using System;
using System.Windows.Threading;

namespace SkypeForBusinessAvailabilityHandler.Internal
{
    public class DispatcherTimerInstance : IDispatcherTimerInstance
    {
        private readonly DispatcherTimer _dispatcherTimer;
        private readonly IDispatcherTimerTick _dispatcherTimerTick;

        /// <summary>
        ///     Constructor of the class
        /// </summary>
        public DispatcherTimerInstance(DispatcherTimer dispatcherTimer, IDispatcherTimerTick dispatcherTimerTick)
        {
            if (dispatcherTimer == null)
            {
                throw new ArgumentNullException(nameof(dispatcherTimer));
            }
            if (dispatcherTimerTick == null)
            {
                throw new ArgumentNullException(nameof(dispatcherTimerTick));
            }
            _dispatcherTimer = dispatcherTimer;
            _dispatcherTimerTick = dispatcherTimerTick;
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