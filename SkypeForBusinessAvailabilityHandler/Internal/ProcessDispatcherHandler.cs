using System;

namespace SkypeForBusinessAvailabilityHandler.Internal
{
    /// <inheritdoc />
    public class ProcessDispatcherHandler : IProcessDispatcherHandler
    {
        private readonly IDispatcherTimerInstance _dispatcherTimerInstance;

        /// <summary>
        ///     Constructor of the class
        /// </summary>
        public ProcessDispatcherHandler(IDispatcherTimerInstance dispatcherTimerInstance)
        {
            _dispatcherTimerInstance = dispatcherTimerInstance ?? throw new ArgumentNullException(nameof(dispatcherTimerInstance));
        }

        /// <inheritdoc />
        public void Run()
        {
            _dispatcherTimerInstance.Value.Start();
        }
    }
}